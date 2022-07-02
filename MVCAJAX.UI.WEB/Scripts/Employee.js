function CustomerListele() {
    $("#customerstabel1 tr").remove();
    var url = "/Home/CustomerListele";
    $("#customerstabel1").html();
    var thead = '<thead><tr><td align="center"><b>ID</b></td><td align="center"><b>Firma İsmi</b></td><td align="center"><b>Müşteri Temsilcisi</b></td></tr></thead>';
    $("#customerstabel1").append(thead);
    $.getJSON(url, function (data) {
        for (var item in data.Result) {
            var deger = '<tbody><tr><td>' + data.Result[item].CustomerID + '</td><td>' + data.Result[item].CompanyName + '</td><td>' + data.Result[item].ContactName + '</td></tr></tbody>';
            $("#customerstabel1").append(deger);
        }
    });
}

function EmployeeListele() {
    $("#employeetabel1 tr").remove();
    var url = "/Home/EmployeeListele";
    $("#employeetabel1").html();
    var thead = '<thead><tr><td align="center" style=""><b>ID</b></td><td align="center"><b>İsim</b></td><td align="center"><b>Soyisim</b></td></tr></thead>';
    $("#employeetabel1").append(thead);
    $.getJSON(url, function (data) {
        for (var item in data.Result) {
            var deger = '<tbody><tr><td>' + data.Result[item].EmployeeID + '</td><td>' + data.Result[item].FirstName + '</td><td>' + data.Result[item].LastName + '</td></tr></tbody>';
            $("#employeetabel1").append(deger);
        }
    });
}

function ProductListele() {
    $("#productstabel1 tr").remove();
    var url = "/Home/ProductListele";
    $("#productstabel1").html();
    var thead = '<thead><tr><td align="center" style=""><b>ID</b></td><td align="center"><b>Ürün Adı</b></td><td align="center"><b>Birim Fiyat</b></td></tr></thead>';
    $("#productstabel1").append(thead);
    $.getJSON(url, function (data) {
        for (var item in data.Result) {
            var deger = '<tbody><tr><td>' + data.Result[item].ProductID + '</td><td>' + data.Result[item].ProductName + '</td><td>' + data.Result[item].UnitPrice + '</td></tr></tbody>';
            $("#productstabel1").append(deger);
        }
    });
}

function CategoryListele() {
    $("#categorytabel1 tr").remove();
    var url = "/Home/CategoryListele";
    $("#categorytabel1").html();
    var thead = '<thead><tr><td align="center"><b>ID</b></td><td align="center"><b>Firma İsmi</b></td><td align="center"><b>Müşteri Temsilcisi</b></td></tr></thead>';
    $("#categorytabel1").append(thead);
    $.getJSON(url, function (data) {
        for (var item in data.Result) {
            var deger = '<tbody><tr><td>' + data.Result[item].CategoryID + '</td><td>' + data.Result[item].CategoryName + '</td><td>' + data.Result[item].Description + '</td></tr></tbody>';
            $("#categorytabel1").append(deger);
        }
    });
}

function OrderListele() {
    $("#orderstabel1 tr").remove();
    var url = "/Home/OrderListele";
    $("#orderstabel1").html();
    var thead = '<thead><tr><td align="center"><b>Sipariş ID</b></td><td align="center"><b>Kargolanacak Ülke</b></td><td align="center"><b>Kargo Adresi</b></td><td align="center"><b>Kargo Tarihi</b></td></tr></thead>';
    $("#orderstabel1").append(thead);
    $.getJSON(url, function (data) {
        for (var item in data) {
            var deger = '<tbody><tr><td>' + data[item].OrderID + '</td><td>' + data[item].ShipCountry + '</td><td>' + data[item].ShipAddress + '</td><td>' + data[item].ShippedDate + '</td></tr></tbody>';
            $("#orderstabel1").append(deger);
        }
    });
}

function OrderDetailsListele() {
    $("#orderdetailstabel1 tr").remove();
    var url = "/Home/OrderDetailsListele";
    $("#orderdetailstabel1").html();
    var thead = '<thead><tr><td align="center"><b>ID</b></td><td align="center"><b>Birim Fiyat</b></td><td align="center"><b>Sipariş Miktarı</b></td><td align="center"><b>Toplam Fiyat</b></td></tr></thead>';
    $("#orderdetailstabel1").append(thead);
    $.getJSON(url, function (data) {
        for (var item in data.Result) {
            var deger = '<tbody><tr><td>' + data.Result[item].OrderID + '</td><td>' + data.Result[item].UnitPrice + ' $</td><td>' + data.Result[item].Quantity + '</td><td><b>' + data.Result[item].total + ' $</b></td></tr></tbody>';
            $("#orderdetailstabel1").append(deger);
        }
    });
}

function RegionListele() {
    $("#regionstabel1 tr").remove();
    var url = "/Home/RegionListele";
    $("#regionstabel1").html();
    var thead = '<thead><tr><td align="center"><b>Konum ID</b></td><td align="center"><b>Coğrafi Konum</b></td></tr></thead>';
    $("#regionstabel1").append(thead);
    $.getJSON(url, function (data) {
        for (var item in data) {
            var deger = '<tbody><tr><td>' + data[item].RegionID + '</td><td>' + data[item].RegionDescription + '</td></tr></tbody>';
            $("#regionstabel1").append(deger);
        }
    });
}

function ShipperListele() {
    $("#shipperstabel1 tr").remove();
    var url = "/Home/ShipperListele";
    $("#shipperstabel1").html();
    var thead = '<thead><tr><td align="center"><b>ID</b></td><td align="center"><b>Kargo Şirketi Adı</b></td><td align="center"><b>Telefon Numarası</b></td></tr></thead>';
    $("#shipperstabel1").append(thead);
    $.getJSON(url, function (data) {
        for (var item in data) {
            var deger = '<tbody><tr><td>' + data[item].ShipperID + '</td><td>' + data[item].CompanyName + '</td><td>' + data[item].Phone + '</td></tr></tbody>';
            $("#shipperstabel1").append(deger);
        }
    });
}

function SupplierListele() {
    $("#supplierstabel1 tr").remove();
    var url = "/Home/SupplierListele";
    $("#supplierstabel1").html();
    var thead = '<thead><tr><td align="center"><b>ID</b></td><td align="center"><b>Tedarikçi Şirket Adı</b></td><td align="center"><b>Müşteri Temsilcisi</b></td></tr></thead>';
    $("#supplierstabel1").append(thead);
    $.getJSON(url, function (data) {
        for (var item in data) {
            var deger = '<tbody><tr><td>' + data[item].SupplierID + '</td><td>' + data[item].CompanyName + '</td><td>' + data[item].ContactName + '</td></tr></tbody>';
            $("#supplierstabel1").append(deger);
        }
    });
}

function TerritoryListele() {
    $("#territoriestabel1 tr").remove();
    var url = "/Home/TerritoryListele";
    $("#territoriestabel1").html();
    var thead = '<thead><tr><td align="center"><b>Bölge ID</b></td><td align="center"><b>Bölge Adı</b></td></tr></thead>';
    $("#territoriestabel1").append(thead);
    $.getJSON(url, function (data) {
        for (var item in data) {
            var deger = '<tbody><tr><td>' + data[item].TerritoryID + '</td><td>' + data[item].TerritoryDescription + '</td></tr></tbody>';
            $("#territoriestabel1").append(deger);
        }
    });
}