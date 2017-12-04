using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy
{
    public class Garage
    {
        Car[] carArray = new Car[4];  //在Garage中定义一个Car类型的数组carArray,其实carArray在这里的本质是一个数组字段  

        //启动时填充一些Car对象  
        public Garage()
        {
            //为数组字段赋值  
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 50);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 45);
        }
        public IEnumerator GetEnumerator()
        {
            return this.carArray.GetEnumerator();
        }
    }

    public class Car
    {
        public Car(string CarName,int CurrentSpeed)
        {
            this.CarName = CarName;
            this.CurrentSpeed = CurrentSpeed;
        }
        public string  CarName { get; set; }
        public int CurrentSpeed { get; set; }
    }
}
