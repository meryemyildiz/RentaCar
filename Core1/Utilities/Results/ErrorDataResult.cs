using System;
using System.Collections.Generic;
using System.Text;

namespace Core1.Utilities.Results
{
   public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message) //tüm bilgilerin içerildiği yer.
                                                                                    //İşlem sonucunu default true aldık
        {

        }
        public ErrorDataResult(T data) : base(data, false) //mesaj vermeme durumu
        {

        }
        public ErrorDataResult(string message) : base(default, false, message) //sadece mesaj verme durumu
                                                                               //ctorda data yazmadım bu yüzden defaultunu aldım
        {

        }
        public ErrorDataResult() : base(default, false) //sadece true döndürme durumu
                                                        //default dataya karşılık gelir.
        {                                              //Veri tipi int se int in defaultunu alır 

        }

    }
}
