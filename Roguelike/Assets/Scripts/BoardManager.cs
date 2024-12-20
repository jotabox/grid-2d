using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;


public class BoardManager : MonoBehaviour
{


    public class CellData
    {
        public bool Passable;
    }


    private Tilemap _tilemap;
    private CellData[,] _cell;
    private Grid _worldPos;

    [SerializeField] private int width;
    [SerializeField] private int height;
    public Tile[] GroundTiles;
    public Tile[] WallTiles;
    public PlayerController player;


    // Start is called before the first frame update
    void Start()
    {
        // aqui o _tilemap está acessando o "tilemap" da componente filho ou seja
        // BoargaManager > Ground > tilemap
        _tilemap = GetComponentInChildren<Tilemap>();

        // inicialização da matriz , que guardara os dados do tile, ex: se é passavel 
        _cell = new CellData[width, height];

        _worldPos = GetComponentInChildren<Grid>();

        // laço for para gerar o boasr"tabuleiro" com as medidas passadas de altura e largura
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //tilenumber recebe um valor aleatorio dos tiles que estao dentro do array "groundtiles"
                //cada numero é que vale a uma posição dentro do array
                //int tileNumber = Random.Range(0, GroundTiles.Length);

                //variavel que vai setar os tiles
                Tile tile;

                //inicia a celula como uma nova instancia de cell data , para que cada celula tenha seu 
                //proprio atributo configurado separado
                _cell[i, j] = new CellData();

                //Essa condição verifica se a posição atual está nas bordas da matriz
                if (j == 0 || i == 0 || j == width - 1 || i == height - 1)
                {
                    //Se a posição está na borda, um tile aleatório é selecionado do array WallTiles para ser usado.
                    //Isso  representa uma parede ou limite do mapa.
                    tile = WallTiles[Random.Range(0, WallTiles.Length)];
                    _cell[i, j].Passable = false;
                }
                else
                {
                    //Para posições que não estão nas bordas, um tile aleatório é selecionado do array GroundTiles,
                    //representando o terreno interior.
                    tile = GroundTiles[Random.Range(0, GroundTiles.Length)];
                    _cell[i, j].Passable = true;
                }

                // aqui estamos setando no mapa o tile escolhido aleatorio no tilenumber , nas posiçoes i e j
                _tilemap.SetTile(new Vector3Int(i, j, 0), tile);
            }

        }

        player.Spawn(this, new Vector2Int(1, 1));
    }
    public Vector3 CellToWorld(Vector2Int cellIndex)
    {
        return _worldPos.GetCellCenterWorld((Vector3Int)cellIndex);
    }

    public CellData GetCellData(Vector2Int cellIndex)
    {
        if (cellIndex.x < 0 || cellIndex.x > width || cellIndex.y < 0 || cellIndex.y > height)
        {
            return null;
        }

        return _cell[cellIndex.x, cellIndex.y];
    }
}
