using System;
using System.Collections.Generic;
using LaDonaRest.Component;
using LaDonaRest.ConcreteComponent;
using LaDonaRest.ConcreteDecorator;

namespace LaDonaRest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Casado myBasicCasado = new BasicCasado();
            //Casado myBasicCasado2 = new BasicCasado();
            //Casado myCompleteCasado = new CompleteCasado();
            //Casado myCompleteCasado2 = new CompleteCasado();

            //myBasicCasado2 = new Starter(myBasicCasado2);
            //myBasicCasado2 = new ThreeSides(myBasicCasado2);
            //myBasicCasado2 = new Dessert(myBasicCasado2);

            //myCompleteCasado2 = new Starter(myBasicCasado2);
            //myCompleteCasado2 = new TwoSides(myBasicCasado2);
            //myCompleteCasado2 = new Dessert(myBasicCasado2);

            //Console.WriteLine(myBasicCasado.GetDescription());
            //Console.Write("Total: ");
            //Console.WriteLine($"{myBasicCasado.GetCost():C2}");
            //Console.WriteLine();

            //Console.WriteLine(myBasicCasado2.GetDescription());
            //Console.Write("Total: ");
            //Console.WriteLine($"{myBasicCasado2.GetCost():C2}");
            //Console.WriteLine();

            //Console.WriteLine(myCompleteCasado.GetDescription());
            //Console.Write("Total: ");
            //Console.WriteLine($"{myCompleteCasado.GetCost():C2}");
            //Console.WriteLine();

            //Console.WriteLine(myCompleteCasado2.GetDescription());
            //Console.Write("Total: ");
            //Console.WriteLine($"{myCompleteCasado2.GetCost():C2}");
            //Console.WriteLine();

            Console.WriteLine("*** LA DOÑA RESTAURANT ***");
            Console.WriteLine("\n>> Place your casado order: ");
            Console.WriteLine();

            LinkedList<Casado> order = new LinkedList<Casado>(); 

            Casado myCasado = null;

            int size = 0;
            bool isNumber = true;
            bool validInput = true;

            Console.Write("First thing first > ");

            bool addAnotherCasadoToOrder = false;

            do
            {
                addAnotherCasadoToOrder = false;
                do
                {
                    Console.WriteLine("What casado size do you want?\n\nChoose:\n\n\t1 >> for regular or\n\t2 >> for big size");
                    isNumber = Int32.TryParse(Console.ReadLine(), out size);

                    if (size == 1)
                    {
                        myCasado = new BasicCasado();
                        validInput = true;
                    }
                    else if (size == 2)
                    {
                        myCasado = new CompleteCasado();
                        validInput = true;
                    }
                    else
                    {
                        validInput = false;
                        Console.WriteLine("\nWrong input, please try again\n");
                    }
                    //Console.WriteLine("isNumber: " + isNumber + "\nvalidInput: " + validInput);

                } while (!isNumber || !validInput);

                if (myCasado != null)
                {
                    int sidesOption = 0;
                    bool correctValue = false;
                    bool addMoreItems = false;

                    do
                    {
                        do
                        {
                            addMoreItems = false;
                            Console.WriteLine("\nExtras:\n\t* 1 side\n\t* 2 sides\n\t* 3 sides\n\t* 4 Starter\n\t* 5 Dessert\n\t* 6 NO EXTRAS\n");
                            correctValue = Int32.TryParse(Console.ReadLine(), out sidesOption);

                            switch (sidesOption)
                            {
                                case 1:
                                    myCasado = new OneSide(myCasado);
                                    break;
                                case 2:
                                    myCasado = new TwoSides(myCasado);
                                    break;
                                case 3:
                                    myCasado = new ThreeSides(myCasado);
                                    break;
                                case 4:
                                    myCasado = new Starter(myCasado);
                                    break;
                                case 5:
                                    myCasado = new Dessert(myCasado);
                                    break;
                                case 6:
                                    break;
                                default:
                                    Console.WriteLine("\nIncorrect input. Please try again\n");
                                    correctValue = false;
                                    break;
                            }

                        } while (!correctValue);

                        Console.WriteLine("\nWould you like to add anything else?\n\tY > yes\n\tN > no");
                        int key2 = Console.Read();
                        //Console.WriteLine("Key: " + key);
                        if (key2 == 89 || key2 == 121) // yes
                        {
                            addMoreItems = true;
                            Console.Clear();
                            Console.WriteLine("*** LA DOÑA RESTAURANT ***");
                            Console.WriteLine();
                        }
                        else if (key2 == 78 || key2 == 110) //no
                        {
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("\nIncorrect input. Please try again.\n");
                        }

                    } while (addMoreItems);
                }

                order.AddLast(myCasado);

                Console.WriteLine("\nWould you like to add another casado to your order?\n\tY > yes\n\tN > no");
                int key = Console.Read();
                //Console.WriteLine("Key: " + key);
                if (key == 89 || key == 121) // yes
                {
                    addAnotherCasadoToOrder = true;
                    Console.Clear();
                    Console.WriteLine("*** LA DOÑA RESTAURANT ***");
                    Console.WriteLine();
                }
                else if (key == 78 || key == 110) //no
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("\nIncorrect input. Please try again.\n");
                }


            } while (addAnotherCasadoToOrder);




            Console.WriteLine("*** LA DOÑA RESTAURANT ***");
            Console.WriteLine();
            Console.WriteLine("Please review your order: \n");

            foreach (var casado in order)
            {
                Console.WriteLine(casado.GetDescription());
                Console.Write("Total: ");
                Console.WriteLine($"{casado.GetCost():C2}");
                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
