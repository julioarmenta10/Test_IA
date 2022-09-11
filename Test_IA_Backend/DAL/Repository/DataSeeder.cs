using DAL.Entities;

namespace DAL.Repository
{
    public class DataSeeder
    {
        private readonly TestIAContext testIAContext;

        public DataSeeder(TestIAContext testIAContext)
        {
            this.testIAContext = testIAContext;
        }

        public void Seed()
        {
            //Dummy Products
            if (!testIAContext.Products.Any())
            {
                var products = new List<Product>()
                {
                        new Product()
                        {
                            //Id = 1, 
                            Stock = 20,
                            Description = "Pizza",
                            SKU = "P12345"
                        },
                        new Product()
                        {
                            Stock = 10,
                            Description = "Hamburguesa",
                            SKU = "H123456"
                        },
                        new Product()
                        {
                            //Id = 1, 
                            Stock = 15,
                            Description = "Sushi",
                            SKU = "S12345"
                        },
                        new Product()
                        {
                            Stock = 35,
                            Description = "Taco de Asada",
                            SKU = "T12345"
                        },
                        new Product()
                        {
                            //Id = 1, 
                            Stock = 20,
                            Description = "Tamal",
                            SKU = "TA1234"
                        },
                        new Product()
                        {
                            Stock = 20,
                            Description = "Pozole",
                            SKU = "P12345"
                        }
                };

                testIAContext.Products.AddRange(products);
                testIAContext.SaveChanges();
            }

            //Orders
            if (!testIAContext.Orders.Any())
            {
                var orders = new List<Order>()
                {
                        new Order()
                        {
                            OrderNumber=1,
                            OrderStatus="Pending",
                            OrderDetails=new List<OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    ProductId=1,
                                    Quantity=1
                                },
                                 new OrderDetail()
                                {
                                    ProductId=2,
                                    Quantity=2
                                }
                            }
                        },
                        new Order()
                        {
                            OrderNumber=2,
                            OrderStatus="Pending",
                            OrderDetails=new List<OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    ProductId=4,
                                    Quantity=2
                                },
                                 new OrderDetail()
                                {
                                    ProductId=5,
                                    Quantity=1
                                }
                            }
                        },
                        new Order()
                        {
                            OrderNumber=3,
                            OrderStatus="Pending",
                            OrderDetails=new List<OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    ProductId=5,
                                    Quantity=3
                                },
                                 new OrderDetail()
                                {
                                    ProductId=4,
                                    Quantity=2
                                }
                            }
                        },

                        new Order()
                        {
                            OrderNumber=4,
                            OrderStatus="In Process",
                            OrderDetails=new List<OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    ProductId=4,
                                    Quantity=2
                                },
                                 new OrderDetail()
                                {
                                    ProductId=1,
                                    Quantity=2
                                }
                            }
                        },
                        new Order()
                        {
                            OrderNumber=5,
                            OrderStatus="In Process",
                            OrderDetails=new List<OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    ProductId=1,
                                    Quantity=3
                                }
                            }
                        },
                        new Order()
                        {
                            OrderNumber=6,
                            OrderStatus="In Process",
                            OrderDetails=new List<OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    ProductId=1,
                                    Quantity=2
                                },
                                 new OrderDetail()
                                {
                                    ProductId=2,
                                    Quantity=2
                                },
                                new OrderDetail()
                                {
                                    ProductId=3,
                                    Quantity=2
                                },
                                 new OrderDetail()
                                {
                                    ProductId=4,
                                    Quantity=2
                                }
                            }
                        },
                        new Order()
                        {
                            OrderNumber=7,
                            OrderStatus="Completed",
                            OrderDetails=new List<OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    ProductId=3,
                                    Quantity=3
                                },
                                 new OrderDetail()
                                {
                                    ProductId=5,
                                    Quantity=3
                                }
                            }
                        },
                        new Order()
                        {
                            OrderNumber=8,
                            OrderStatus="Completed",
                            OrderDetails=new List<OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    ProductId=1,
                                    Quantity=1
                                },
                                 new OrderDetail()
                                {
                                    ProductId=2,
                                    Quantity=3
                                }
                            }
                        },
                        new Order()
                        {
                            OrderNumber=9,
                            OrderStatus="Completed",
                            OrderDetails=new List<OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    ProductId=4,
                                    Quantity=4
                                },
                                 new OrderDetail()
                                {
                                    ProductId=3,
                                    Quantity=2
                                }
                            }
                        },
                        new Order()
                        {
                            OrderNumber=10,
                            OrderStatus="Delivered",
                            OrderDetails=new List<OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    ProductId=1,
                                    Quantity=4
                                }
                            }
                        },
                        new Order()
                        {
                            OrderNumber=11,
                            OrderStatus="Delivered",
                            OrderDetails=new List<OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    ProductId=1,
                                    Quantity=4
                                },
                                 new OrderDetail()
                                {
                                    ProductId=2,
                                    Quantity=4
                                },new OrderDetail()
                                {
                                    ProductId=3,
                                    Quantity=2
                                },
                                 new OrderDetail()
                                {
                                    ProductId=6,
                                    Quantity=1
                                }
                            }
                        },
                        new Order()
                        {
                            OrderNumber=12,
                            OrderStatus="Delivered",
                            OrderDetails=new List<OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    ProductId=4,
                                    Quantity=4
                                }
                            }
                        },
                        new Order()
                        {
                            OrderNumber=13,
                            OrderStatus="Canceled",
                            OrderDetails=new List<OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    ProductId=1,
                                    Quantity=5
                                },
                                 new OrderDetail()
                                {
                                    ProductId=2,
                                    Quantity=5
                                }
                            }
                        },
                        new Order()
                        {
                            OrderNumber=14,
                            OrderStatus="Canceled",
                            OrderDetails=new List<OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    ProductId=1,
                                    Quantity=5
                                },
                                 new OrderDetail()
                                {
                                    ProductId=2,
                                    Quantity=5
                                }
                            }
                        },
                        new Order()
                        {
                            OrderNumber=15,
                            OrderStatus="Canceled",
                            OrderDetails=new List<OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    ProductId=1,
                                    Quantity=5
                                },
                                 new OrderDetail()
                                {
                                    ProductId=2,
                                    Quantity=5
                                }
                            }
                        }
                };

                testIAContext.Orders.AddRange(orders);
                testIAContext.SaveChanges();
            }
        }
    }
}
