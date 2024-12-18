using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;


public class BoardManager : MonoBehaviour
{

    private Tilemap _tilemap;

    [SerializeField] private float width;
    [SerializeField] private float height;
    public Tile[] GroundTiles;
    public Tile[] WallTiles;


    // Start is called before the first frame update
    void Start()
    {
        // aqui o _tilemap está acessando o "tilemap" da componente filho ou seja
        // BoargaManager > Ground > tilemap
        _tilemap = GetComponentInChildren<Tilemap>();

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

                //Essa condição verifica se a posição atual está nas bordas da matriz
                if (j == 0 || i == 0 || j == width - 1  || i == height -1)
                {
                    //Se a posição está na borda, um tile aleatório é selecionado do array WallTiles para ser usado.
                    //Isso  representa uma parede ou limite do mapa.
                    tile = WallTiles[Random.Range(0, WallTiles.Length)];
                }
                else
                {
                    //Para posições que não estão nas bordas, um tile aleatório é selecionado do array GroundTiles,
                    //representando o terreno interior.
                    tile = GroundTiles[Random.Range(0, GroundTiles.Length)];
                }

                // aqui estamos setando no mapa o tile escolhido aleatorio no tilenumber , nas posiçoes i e j
                _tilemap.SetTile(new Vector3Int(i,j,0),tile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
