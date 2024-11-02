using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private Camera sceneCamera;
    [SerializeField] private LayerMask placementLayerMask;
    [SerializeField] private GameObject cellIndicator;
    [SerializeField] private Grid grid;
    [SerializeField] private GameObject gridPanel;
    [SerializeField] private Wepen_Data_Base weaponDatabase;
    [SerializeField] private GridManager gridManager;
    [SerializeField] private Game_Maneger uiManager;

    private Renderer cellIndicatorRenderer;
    [SerializeField] private GameObject currentTower;
    private Vector3 lastPosition;
    public bool isPlacementActive = false; // Variable to control placement state

    public GameObject RayCAst_Wall;
    private void Start()
    {
        uiManager.UpdateUI();
        cellIndicatorRenderer = cellIndicator.GetComponentInChildren<Renderer>();
        weaponDatabase.SelectedTowerPlace = Vector3Int.zero;
        cellIndicator.SetActive(false);
        gridPanel.SetActive(false);
    }


    private void Update()
    {
        if (isPlacementActive)
        {
            PlaceTowerOnMap();
        }
    }

    public void SetPlacementActive(bool active)
    {
        isPlacementActive = active;
        cellIndicator.SetActive(active);
        gridPanel.SetActive(active);
    }

    public void PlaceButton( object data)
    {
        weaponDatabase.SelectedWeaponId = (int)data;
        SetPlacementActive(true); // Activate placement mode
    }

    private void PlaceTowerOnMap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = GetSelectedMapPosition();
            Vector3Int gridPos = grid.WorldToCell(mousePosition);
            weaponDatabase.SelectedTowerPlace = gridPos;
            cellIndicator.transform.position = grid.CellToWorld(gridPos);

            if (currentTower != null)
            {
                currentTower.transform.position = grid.CellToWorld(gridPos);
            }
            else
            {
                if (!uiManager.WithdrawMoney(weaponDatabase.WeaponsList[weaponDatabase.SelectedWeaponId].weaponPrice))
                {
                    // Handle insufficient funds
                    return;
                }

                if (!gridManager.IsPositionOccupied(gridPos))
                {
                    cellIndicatorRenderer.material.color = Color.white;
                    Vector3 worldPosition = grid.CellToWorld(gridPos);
                    worldPosition.y = 0f;

                    currentTower = Instantiate(weaponDatabase.WeaponsList[weaponDatabase.SelectedWeaponId].weaponPrefab, worldPosition, Quaternion.identity);

                    
                }
                else
                {
                    uiManager.DepositMoney(weaponDatabase.WeaponsList[weaponDatabase.SelectedWeaponId].weaponPrice);
                    cellIndicatorRenderer.material.color = Color.red;
                }
            }
        }
    }

    private Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = sceneCamera.nearClipPlane;

        Ray ray = sceneCamera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100, placementLayerMask))
        {
            lastPosition = hit.point;
        }

        return lastPosition;
    }

    public void OccupySelectedPlace()
    {
        gridManager.OccupyPosition(weaponDatabase.SelectedTowerPlace);
        ResetPlacementState();
    }

    public void DestroySelectedObject()
    {
        uiManager.DepositMoney(weaponDatabase.WeaponsList[weaponDatabase.SelectedWeaponId].weaponPrice);
        Destroy(currentTower);
        ResetPlacementState(); 
        
      
       
    }

    private void ResetPlacementState()
    {
        cellIndicator.SetActive(false);
        cellIndicator.transform.position = Vector3.zero;
        weaponDatabase.SelectedTowerPlace = Vector3Int.zero;
        gridPanel.SetActive(false);
        weaponDatabase.SelectedWeaponId = -1;
        isPlacementActive = false; // Deactivate placement mode
        currentTower = null;
    }
}
