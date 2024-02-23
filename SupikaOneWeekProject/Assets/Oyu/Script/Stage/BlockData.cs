using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BlockData.BlockInfo;

public class BlockData : MonoBehaviour
{

    public class BlockInfo
    {
        public GameObject _object;

        public enum BlockType
        {
            Black,
            Red,
            Bule,

            Enpty,

            None
        }
        public BlockType _type;
    }

    [SerializeField] private List<BlockInfo> blockInfoList = new List<BlockInfo>();

    [SerializeField] private GameObject BlackBlockObj;
    [SerializeField] private GameObject RedBlockObj;
    [SerializeField] private GameObject BlueBlockObj;
    [SerializeField] private GameObject EnptyBlockObj;

    [SerializeField] private Transform OutBlueBlockObject;

    [SerializeField] private GridLayoutGroup gridLayoutGroup = null;
    public GridLayoutGroup GetGridLayoutGroup()
    {
        return gridLayoutGroup;
    }
    

    public List<BlockInfo> GetBlockInfoList()
    {
        return blockInfoList;
    }

    public BlockInfo GetBlockInfo(GameObject block)
    {
        //idを取得
        int id = block.GetInstanceID();

        //もっといい方法があるかもしれない
        foreach (BlockInfo b in blockInfoList)
        {
            if (b._object.GetInstanceID() == id)
            {
                return b;
            }
        }

        return null;
    }

    public void AddBlockInfo(GameObject block, BlockType blockType)
    {
        BlockInfo blockInfo = new BlockInfo();
        blockInfo._object = block;
        blockInfo._type = blockType;
        blockInfoList.Add(blockInfo);
        Debug.Log("AddblockInfo");
    }

    public void OutBlueBlock(GameObject blueBlock)
    {
        //透明ブロックを入れる
        InputBlockInfo(BlockType.Enpty, blueBlock.transform.GetSiblingIndex());

        //親オブジェクト変更
        blueBlock.transform.SetParent(OutBlueBlockObject);
    }

    //ブロックの情報を任意の場所（配列位置）に追加 一つずれるので注意
    public BlockInfo InputBlockInfo(BlockType nextType, int siblingIndex)
    {
        if (nextType == BlockType.None) return null;

        BlockInfo blockInfo = new BlockInfo();
        blockInfo._type = nextType;

        switch (nextType)
        {
            case BlockType.Black:
                blockInfo._object = Instantiate(BlackBlockObj, transform);
                break;
            case BlockType.Red:
                blockInfo._object = Instantiate(RedBlockObj, transform);
                break;
            case BlockType.Bule:
                blockInfo._object = Instantiate(BlueBlockObj, transform);
                break;
            case BlockType.Enpty:
                blockInfo._object = Instantiate(EnptyBlockObj, transform);
                break;
            case BlockType.None:
                break;
        }

        blockInfoList.Add(blockInfo);
        blockInfo._object.transform.SetSiblingIndex(siblingIndex);
        Debug.Log("AddblockInfo");
        return blockInfo;
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
