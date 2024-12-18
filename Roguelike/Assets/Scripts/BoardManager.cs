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
        // aqui o _tilemap est� acessando o "tilemap" da componente filho ou seja
        // BoargaManager > Ground > tilemap
        _tilemap = GetComponentInChildren<Tilemap>();

        // la�o for para gerar o boasr"tabuleiro" com as medidas passadas de altura e largura
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //tilenumber recebe um valor aleatorio dos tiles que estao dentro do array "groundtiles"
                //cada numero � que vale a uma posi��o dentro do array
                //int tileNumber = Random.Range(0, GroundTiles.Length);

                //variavel que vai setar os tiles
                Tile tile;

                //Essa condi��o verifica se a posi��o atual est� nas bordas da matriz
                if (j == 0 || i == 0 || j == width - 1  || i == height -1)
                {
                    //Se a posi��o est� na borda, um tile aleat�rio � selecionado do array WallTiles para ser usado.
                    //Isso  representa uma parede ou limite do mapa.
                    tile = WallTiles[Random.Range(0, WallTiles.Length)];
                }
                else
                {
                    //Para posi��es que n�o est�o nas bordas, um tile aleat�rio � selecionado do array GroundTiles,
                    //representando o terreno interior.
                    tile = GroundTiles[Random.Range(0, GroundTiles.Length)];
                }

                // aqui estamos setando no mapa o tile escolhido aleatorio no tilenumber , nas posi�oes i e j
                _tilemap.SetTile(new Vector3Int(i,j,0),tile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
