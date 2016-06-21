using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  

namespace Hw1

{
	class MainClass
	{
		public static void Main (string[] args)

		{
			double length = 1;
			double width =1;

			Console.WriteLine("Please enter the Length of your Rectangle");  
			length = double.Parse(Console.ReadLine());  

			Console.WriteLine("Please enter the width of your Rectangle");  
			width = double.Parse(Console.ReadLine()); 

			Rectangle a = new Rectangle(length, width);
			System.Threading.Thread.Sleep(1000); 

			Console.WriteLine ("The area of your Rectangle is {0:F2} ", a.Area);
			Console.ReadKey();  
		}

	}
	class Rectangle
	{
		private double length = 1;
		private double width =1;

		public Rectangle(double length, double width)
		{
			Length = length;
			Width = width;
		}

		public double Length 
		{
			get{ return this.length;}
			set{ if (value <=0.0f ) this.length = 1.0f; 
			else this.length = value; }
		}

		public double Width 
		{
			get{ return this.width;}
			set{ if (value <=0.0f ) this.width = 1.0f; 
			else this.width = value; }
		}

		public double Area
		{
			get {return (Length*Width);}
		}
	}
		
	}
	

