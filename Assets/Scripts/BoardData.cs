using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardData : MonoBehaviour
{
    publick static BoardData Instance

    public struct BoardData
    {
        public int[] unsolvedsq;
        public int[] solvedsq;

        public BoardData(int[] unsolved, int[] solved) : this()
        {
            this.unsolvedsq = unsolved;
            this.solvedsq = solved;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
