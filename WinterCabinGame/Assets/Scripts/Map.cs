using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private Button rightButton;

    [SerializeField]
    private Button leftButton;

    [SerializeField]
    private BookContent maps;

    [SerializeField]
    private Renderer mapRenderer;

    public int currentMapPage { get; private set; }

    private int selectedSection = 0;

    public Highlightable highlight { get; private set; }

    private void Start()
    {
        rightButton.OnCLick += HandleButtonClick;
        leftButton.OnCLick += HandleButtonClick;
        highlight.OnCLick += HandleHighlightClick;
    }

    private void HandleButtonClick(Button button)
    {
        if(button == rightButton)
            ChangeMapPage(currentMapPage, 1);
        else if(button == leftButton)
            ChangeMapPage(currentMapPage, -1);
        else
            return;
    }

    private void HandleHighlightClick(Highlightable section)
    {
        if(section.id == 1)
            selectedSection = 1;
        else if(section.id == 2)
            selectedSection = 2;
        else if(section.id == 3)
            selectedSection = 3;
        else if(section.id == 4)
            selectedSection = 4;
        else if(section.id == 5)
            selectedSection = 5;
        else if(section.id == 6)
            selectedSection = 6;
        else
            return;
    }

    private void ChangeMapPage(int curpage, int page)
    {
        if(curpage + page >= maps.contents.Count || curpage + page < 0)
        {
            return;
        } 
        else
        {
            currentMapPage += page;
            UpdateMapPage();
        }
    }

    private void UpdateMapPage()
    {
        Material newMaterial = maps.contents[currentMapPage];
        mapRenderer.material = newMaterial;
        
        Debug.Log($"{currentMapPage}");
    }
}
