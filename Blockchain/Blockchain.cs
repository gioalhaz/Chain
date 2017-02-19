using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    public class Blockchain
    {
        public const int DEFAULT_DIFFICALTY = 4;
        private const string EMPTY_HASH = "0000000000000000000000000000000000000000000000000000000000000000";

        public List<Block> Chain { get; private set; }

        public int Difficulty { set; get; }

        public void Init(int count, int difficulty)
        {
            Chain = new List<Block>(count);
            Difficulty = difficulty;

            for (int i = 0; i < count; i++)
            {
                var block = new Block();

                block.Difficulty = difficulty;
                block.Data = "";

                add(block);
            }
        }

        public void add(Block block)
        {
            if (Chain.Count > 0)
            {
                block.PrevBlockHash = Chain.Last().Pow;
                block.BlockNumber = (Chain.Count+1).ToString();
            }
            else
            {
                block.PrevBlockHash = EMPTY_HASH;
                block.BlockNumber = "1";
            }

            block.Difficulty = DEFAULT_DIFFICALTY;
            block.recalculate();
            Chain.Add(block);
        }

        public void recalculate()
        {
            Block previous = null;
            foreach (var block in Chain)
            {
                block.PrevBlockHash = (previous == null) ? EMPTY_HASH : previous.Pow;
                block.Difficulty = Difficulty;
                block.recalculate();

                previous = block;
            }
        }

        /// <summary>
        /// Checks chain for consistancy
        /// 1. Does blocks ref to prev block is correct
        /// 2. Is POW hash correct
        /// </summary>
        /// <returns></returns>
        public bool Check()
        {
            bool result = true;
            foreach (var block in Chain)
            {
                block.Check();
            }

            return result;
        }
    }
}
