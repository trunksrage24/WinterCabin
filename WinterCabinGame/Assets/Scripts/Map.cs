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

    [SerializeField]
    private Highlightable[] highlights;

    public int currentMapPage { get; private set; }

    public int selectedSection { get; private set; }

    private Highlightable previousSection;

    private void Start()
    {
        rightButton.OnCLick += HandleButtonClick;
        leftButton.OnCLick += HandleButtonClick;

        foreach (Highlightable highlight in highlights)
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
        selectedSection = section.id;

        if (previousSection != null)
            previousSection.SelectionUpdate();
        previousSection = section;
        Debug.Log($"{selectedSection}");
    }

    private void ChangeMapPage(int curpage, int page)
    {
        CleanMap();

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

    private void CleanMap()
    {
        if (previousSection != null)
        {
            previousSection.SelectionUpdate();
            previousSection = null;
        }
        selectedSection = -1;
    }
}
