using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int columns = 0;
    public int rows = 0;
    public float all_sq_offset = 0.0f;
    public Vector2 start_position = new Vector2(0.0f, 0.0f);

    public GameObject grid_square;

    private List<GameObject> grid_squares = new List<GameObject>();

    void Start()
    {
        if(grid_square.GetComponent<GridSquare>() == null)
            Debug.LogError("grid_square blah blah");
        createGrid();
        SetGridNumbers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createGrid()
    {
        spawnGridSquares();
        setSquarePosition();
    }

    private void spawnGridSquares()
    {
        for(int r = 0; r < rows; r++)
        {
            for(int c = 0; c < columns; c++)
            {
                grid_squares.Add(Instantiate(grid_square) as GameObject);
                grid_squares[grid_squares.Count - 1].transform.parent = this.transform; //instantiate this game object as a child of the object holding this script
            }
        }
    }

    private void setSquarePosition()
    {
        var square_rect = grid_squares[0].GetComponent<RectTransform>();
        Vector2 offset = new Vector2();
        offset.x = square_rect.rect.width * square_rect.transform.localScale.x + all_sq_offset;
        offset.y = square_rect.rect.height * square_rect.transform.localScale.y + all_sq_offset;

        int column_number = 0;
        int row_number = 0;

        foreach(GameObject square in grid_squares)
        {
            if(column_number + 1 > columns)
            {
                row_number++;
                column_number = 0;
            }

            var pos_x_offset = offset.x  * column_number;
            var pos_y_offset = offset.y  * row_number;
            square.GetComponent<RectTransform>().anchoredPosition = new Vector3(start_position.x + pos_x_offset, start_position.y - pos_y_offset);
            column_number++;
        }
    }

    private void SetGridNumbers()
    {
        foreach (var square in grid_squares)
        {
            square.GetComponent<GridSquare>().SetNumber(Random.Range(0, 10));
        }
    }
}
