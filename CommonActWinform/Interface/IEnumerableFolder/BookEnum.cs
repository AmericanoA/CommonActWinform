using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonActWinform.Interface.IEnumerableFolder
{
    class BookEnum : IEnumerable
    {
        

        private class Node : IEnumerator
        {
            private int[] data = new int[]
            {
                1,2,3,4,5,6,7,8,9,10
            };
            private string[] data2 = new string[]
            {
                "A","B","C","D","E","F","G","H","I"
            };
            private int pos = 0;
            public object Current
            {
                //+ Current 안에서 pos 위치에따라 반환값 자유 변경
                get
                {
                    if (pos < data.Length)
                    {

                        return data[pos - 1];
                    }
                    else
                    {
                        return data2[pos - 10];
                    }
                }
            }
            public bool MoveNext()
            {
                //3. MoveNext 선진행하여 다음 인자 확인하여 배열의 끝이 아닐시 true 및 position 변경 배열의 끝일시 false   
                if (pos >= data.Length)
                {
                    //4. false 반환시 foreach 종료
                    if (pos >= data2.Length + 9)
                    {
                        return false;
                    }
                }
                pos++;

                return true;
            }

            public void Reset()
            {
                pos = 0;
            }
        }

        //1. Enumerator 생성
        private IEnumerator node = new Node();
        public IEnumerator GetEnumerator()
        {
            //2. foreach 진입시 객체 리셋 및 Enumerator 반환
            node.Reset();
            return node;
        }
    }
}

