using MVCAJAX.UI.WEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAJAX.UI.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GrafikOlustur()
        {
            return Json(ulkeler(), JsonRequestBehavior.AllowGet);
        }
        public List<Class1> ulkeler()
        {
            wgEntities db = new wgEntities();

            var joinlist = from tc in db.TurkeyCities
                           join ot in db.OtherTable on tc.ID equals ot.ID
                           select new { cityname = tc.CityName, criminalcount = ot.Param1 * tc.CriminalCount };
            var paramsList = new Dictionary<string, Int64>();
            foreach (var item in joinlist)
            {
                paramsList.Add(item.cityname, (Int64)item.criminalcount);
            }
            List<Class1> list = paramsList.Select(p => new Class1 { CityName = p.Key, CriminalCount = p.Value }).ToList();
            
            return list;
        }

        public List<Class1> ulkeler1()
        {
            List<Class1> cs = new List<Class1>();
            List<Class1> cs1 = new List<Class1>();
            wgEntities db = new wgEntities();

            cs = db.TurkeyCities.Select(x => new Class1
            {
                CityName = x.CityName,
                CriminalCount = (Int64)x.CriminalCount
            }).ToList();
            return cs;
        }


        public JsonResult ActionLinkFill()
        {
            using (var dbContext = new nwEntities())
            {
                var metadata = ((IObjectContextAdapter)dbContext).ObjectContext.MetadataWorkspace;

                var tables = metadata.GetItemCollection(DataSpace.SSpace)
                    .GetItems<EntityContainer>()
                    .Single()
                    .BaseEntitySets
                    .OfType<EntitySet>()
                    .Where(s => !s.MetadataProperties.Contains("Type")
                    || s.MetadataProperties["Type"].ToString() == "Tables");
                string[] tablearray;
                int i = 0;
                foreach (var table in tables)
                {
                    var tableName = table.MetadataProperties.Contains("Table")
                        && table.MetadataProperties["Table"].Value != null
                        ? table.MetadataProperties["Table"].Value.ToString()
                        : table.Name;
                    if (table.Name != "sysdiagrams" && table.Name != "CustomerCustomerDemo" && table.Name != "EmployeeTerritories" && table.Name != "CustomerDemographics")
                    {
                        i++;
                    }
                }
                tablearray = new string[i];
                int j = 0;
                foreach (var table in tables)
                {
                    var tableName = table.MetadataProperties.Contains("Table")
                        && table.MetadataProperties["Table"].Value != null
                        ? table.MetadataProperties["Table"].Value.ToString()
                        : table.Name;
                    if (table.Name != "sysdiagrams" && table.Name != "CustomerCustomerDemo" && table.Name != "EmployeeTerritories" && table.Name != "CustomerDemographics")
                    {
                        tablearray[j] = table.ToString();
                        j++;
                    }

                }
                {
                    var tmp = tablearray[0];
                    tablearray[0] = tablearray[2];
                    tablearray[2] = tmp;
                }
                {
                    var tmp = tablearray[1];
                    tablearray[1] = tablearray[2];
                    tablearray[2] = tmp;
                }
                {
                    var tmp = tablearray[2];
                    tablearray[2] = tablearray[3];
                    tablearray[3] = tmp;
                }
                {
                    var tmp = tablearray[3];
                    tablearray[3] = tablearray[4];
                    tablearray[4] = tmp;
                }
                {
                    var tmp = tablearray[4];
                    tablearray[4] = tablearray[5];
                    tablearray[5] = tmp;
                }

                var veriler = tablearray.ToList();
                return Json(
                new
                {
                    Result = from obj in veriler
                             select new
                             {
                                 name = obj
                             }
                }, JsonRequestBehavior.AllowGet
                );

                //return Json(veriler, JsonRequestBehavior.AllowGet);
            }
        }




        public ActionResult Customers()
        {
            return View();
        }
        public ActionResult Employees()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }
        public ActionResult Categories()
        {
            return View();
        }
        public ActionResult Orders()
        {
            return View();
        }
        public ActionResult OrderDetails()
        {
            return View();
        }
        public ActionResult Region()
        {
            return View();
        }
        public ActionResult Shippers()
        {
            return View();
        }
        public ActionResult Suppliers()
        {
            return View();
        }
        public ActionResult Territories()
        {
            return View();
        }




        public JsonResult CustomerListele()
        {
            var db = new nwEntities();
            var data = db.Customers.ToList();
            return Json(
                new
                {
                    Result = from obj in data
                             select new
                             {
                                 obj.CustomerID,
                                 obj.CompanyName,
                                 obj.ContactName
                             }
                }, JsonRequestBehavior.AllowGet
                );
        }
        public JsonResult EmployeeListele()
        {
            var db = new nwEntities();
            var data = db.Employees.ToList();
            return Json(
                new
                {
                    Result = from obj in data
                             select new
                             {
                                 obj.EmployeeID,
                                 obj.FirstName,
                                 obj.LastName
                             }
                }, JsonRequestBehavior.AllowGet
                );
        }
        public JsonResult ProductListele()
        {
            var db = new nwEntities();
            var data = db.Products.ToList();
            return Json(
                new
                {
                    Result = from obj in data
                             select new
                             {
                                 obj.ProductID,
                                 obj.ProductName,
                                 obj.UnitPrice
                             }
                }, JsonRequestBehavior.AllowGet
                );
        }
        public JsonResult CategoryListele()
        {
            var db = new nwEntities();
            var data = db.Categories.ToList();
            return Json(
                new
                {
                    Result = from obj in data
                             select new
                             {
                                 obj.CategoryID,
                                 obj.CategoryName,
                                 obj.Description
                             }
                }, JsonRequestBehavior.AllowGet
                );
        }
        public class OrdersClass
        {
            public int OrderID { get; set; }
            public string ShipCountry { get; set; }
            public string ShipAddress { get; set; }
            public string ShippedDate { get; set; }
        }
        public JsonResult OrderListele()
        {
            var db = new nwEntities();
            var data = db.Orders.ToList();
            List<OrdersClass> xvalues = new List<OrdersClass>();
            foreach (var item in data)
            {
                xvalues.Add(new OrdersClass()
                {
                    OrderID = item.OrderID,
                    ShipCountry = item.ShipCountry,
                    ShipAddress = item.ShipAddress,
                    ShippedDate = Convert.ToDateTime(item.ShippedDate).ToShortDateString() + " " + Convert.ToDateTime(item.ShippedDate).ToShortTimeString()
                });
            }
            return Json(xvalues, JsonRequestBehavior.AllowGet);
        }
        public JsonResult OrderDetailsListele()
        {
            var db = new nwEntities();
            var data = db.OrderDetails.ToList();
            return Json(
                new
                {
                    Result = from obj in data
                             select new
                             {
                                 obj.OrderID,
                                 obj.UnitPrice,
                                 obj.Quantity,
                                 total = obj.UnitPrice * obj.Quantity
                             }
                }, JsonRequestBehavior.AllowGet
                );
        }
        public class RegionsClass
        {
            public int RegionID { get; set; }
            public string RegionDescription { get; set; }
        }
        public JsonResult RegionListele()
        {
            var db = new nwEntities();
            var data = db.Region.ToList();
            List<RegionsClass> xvalues = new List<RegionsClass>();
            foreach (var item in data)
            {
                xvalues.Add(new RegionsClass()
                {
                    RegionID = item.RegionID,
                    RegionDescription = item.RegionDescription
                });
            }
            return Json(xvalues, JsonRequestBehavior.AllowGet);
        }
        public class ShippersClass
        {
            public int ShipperID { get; set; }
            public string CompanyName { get; set; }
            public string Phone { get; set; }
        }
        public JsonResult ShipperListele()
        {
            var db = new nwEntities();
            var data = db.Shippers.ToList();
            List<ShippersClass> xvalues = new List<ShippersClass>();
            foreach (var item in data)
            {
                xvalues.Add(new ShippersClass()
                {
                    ShipperID = item.ShipperID,
                    CompanyName = item.CompanyName,
                    Phone = item.Phone
                });
            }
            return Json(xvalues, JsonRequestBehavior.AllowGet);
        }
        public class SuppliersClass
        {
            public int SupplierID { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
        }
        public JsonResult SupplierListele()
        {
            var db = new nwEntities();
            var data = db.Suppliers.ToList();
            List<SuppliersClass> xvalues = new List<SuppliersClass>();
            foreach (var item in data)
            {
                xvalues.Add(new SuppliersClass()
                {
                    SupplierID = item.SupplierID,
                    CompanyName = item.CompanyName,
                    ContactName = item.ContactName
                });
            }
            return Json(xvalues, JsonRequestBehavior.AllowGet);
        }
        public class TerritoriessClass
        {
            public string TerritoryID { get; set; }
            public string TerritoryDescription { get; set; }
        }
        public JsonResult TerritoryListele()
        {
            var db = new nwEntities();
            var data = db.Territories.ToList();
            List<TerritoriessClass> xvalues = new List<TerritoriessClass>();
            foreach (var item in data)
            {
                xvalues.Add(new TerritoriessClass()
                {
                    TerritoryID = item.TerritoryID,
                    TerritoryDescription = item.TerritoryDescription
                });
            }
            return Json(xvalues, JsonRequestBehavior.AllowGet);
        }
    }
}