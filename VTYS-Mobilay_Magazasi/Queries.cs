using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTYS_Mobilay_Magazasi
{
    //SQL komutlarının bulunduğu sınıf
    class Queries
    {

        //DONT FORGET TO DELETE mydb!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        readonly public static string newID = "SELECT max({0}) FROM {1};";


        //=================================================
        //=================== Overview ====================
        //=================================================

        readonly public static string productsCount = "SELECT count(*) FROM mydb.product;";
        readonly public static string pro_setCount = "SELECT count(*) FROM mydb.product where attributeSet_attributeSet_ID ={0};";
        readonly public static string attributeSets = "SELECT * FROM mydb.attributeset;";
        readonly public static string attributeSetsCount = "SELECT count(*) FROM mydb.attributeset;";
        readonly public static string attributeSetName = "SELECT set_name FROM mydb.attributeset where attributeSet_ID ={0};";
        readonly public static string last5Pro = "SELECT pro_name, pro_description, pro_price, pro_stock FROM mydb.product ORDER BY product_ID DESC LIMIT 5;";
        readonly public static string reStockPro = "SELECT pro_name, pro_description, pro_price, pro_stock FROM mydb.product where pro_stock < 2;";

        readonly public static string sellCount ="SELECT count(*) FROM mydb.sell;";
        readonly public static string sell_cusCount= "SELECT count(*) FROM mydb.sell where customer_customer_ID ={0};";
        readonly public static string customersData = "SELECT customer_ID, concat(cus_name,' ', cus_lastName)as name FROM mydb.customer;";
        readonly public static string customersCount = "SELECT count(*) FROM mydb.customer;";
        readonly public static string customersName = "SELECT concat(cus_name, ' ', cus_lastName)as name FROM mydb.customer where customer_ID ={0};";
        readonly public static string last5Sell = "SELECT concat(c.cus_name, ' ', c.cus_lastName)as name, p.pro_name,s.sel_price, s.sel_qty FROM mydb.sell s join customer c on c.customer_ID = s.customer_customer_ID join product p on p.product_ID = s.product_product_ID ORDER BY sell_ID DESC LIMIT 5;";

        readonly public static string districtsCount = "SELECT count(*) FROM mydb.district;";
        readonly public static string dis_cusCount = "SELECT count(*) FROM customer where district_district_ID = {0};";
        readonly public static string districtData = "SELECT district_ID, dis_name FROM mydb.district;";
        readonly public static string districName = "SELECT concat(dis_name ,' - ', prov_name)as name FROM mydb.district d join province p on p.province_ID = d.province_province_ID where d.district_ID ={0};";

        readonly public static string buyCount = "SELECT count(*) FROM mydb.buy;";
        readonly public static string buy_supCount = "SELECT count(*) FROM mydb.buy where supplier_supplier_ID ={0};";
        readonly public static string suppliersData = "SELECT supplier_ID, sup_name as 'name' FROM mydb.supplier;";
        readonly public static string suppliersCount = "SELECT count(*) FROM supplier;";
        readonly public static string suppliersName = "SELECT sup_name as 'name' FROM mydb.supplier where supplier_ID ={0};";
        readonly public static string last5Buy ="SELECT s.sup_name as 'name', p.pro_name, b.buy_price, b.buy_qty FROM mydb.buy b join supplier s on s.supplier_ID = b.supplier_supplier_ID join product p on p.product_ID = b.product_product_ID ORDER BY Buy_ID DESC LIMIT 5;";
        readonly public static string dis_supCount = "SELECT count(*) FROM supplier where district_district_ID = {0};";


        readonly public static string last5Incomes = "SELECT i.inc_description, i.inc_amount, a.act_name FROM incomes i join activity a on i.activity_activity_ID = a.activity_ID ORDER BY i.incomes_ID DESC LIMIT 5;";
        readonly public static string last5Expenses = "SELECT e.exp_description, e.exp_amount, a.act_name FROM expenses e join activity a on e.activity_activity_ID = a.activity_ID ORDER BY e.expenses_ID DESC LIMIT 5;";


        //=================================================
        //=================== prodcts =====================
        //=================================================
        readonly public static string products = "select p.product_ID as \"ID\", p.pro_name as \"Name\",pro_description as \"Description\",pro_price as \"Price\",pro_stock as \"Stock\", ats.set_name as \"Category\" from product p join attributeset ats on p.attributeSet_attributeSet_ID = ats.attributeSet_ID order by {0};";
        readonly public static string productsAttributes = "select att.att_name,av.val_value from product_attributes pa join product p on pa.product_product_ID = p.product_ID join attributeset ats on pa.attributeSet_attributeSet_ID = ats.attributeSet_ID join attribute att on pa.attribute_attribute_ID = att.attribute_ID join attributevalue av on pa.attributeValue_attributeValue_ID = av.attributeValue_ID where p.product_ID = {0};";

        readonly public static string productsFiltering = "SELECT p.product_ID as \"ID\", p.pro_name as \"Name\", pro_description as \"Description\", pro_price as \"Price\", pro_stock as \"Stock\", ats.set_name as \"Category\" FROM product_attributes pa join product p on pa.product_product_ID = p.product_ID join attributeset ats on pa.attributeSet_attributeSet_ID = ats.attributeSet_ID where ats.attributeSet_ID= {0} group by p.product_ID;";

        readonly public static string productsBasicFilter= "select p.product_ID as \"ID\", p.pro_name as \"Name\",pro_description as \"Description\",pro_price as \"Price\",pro_stock as \"Stock\", ats.set_name as \"Category\" from product p join attributeset ats on p.attributeSet_attributeSet_ID = ats.attributeSet_ID where {0} {1} {2};";
        readonly public static string productsBetweenFilter = "select p.product_ID as \"ID\", p.pro_name as \"Name\",pro_description as \"Description\",pro_price as \"Price\",pro_stock as \"Stock\", ats.set_name as \"Category\" from product p join attributeset ats on p.attributeSet_attributeSet_ID = ats.attributeSet_ID where {0} between {1} and {2};";
        readonly public static string productsSearch = "select p.product_ID as \"ID\", p.pro_name as \"Name\",pro_description as \"Description\",pro_price as \"Price\",pro_stock as \"Stock\", ats.set_name as \"Category\" from product p join attributeset ats on p.attributeSet_attributeSet_ID = ats.attributeSet_ID where pro_name LIKE '%{0}%';";

        readonly public static string attributeSet = "SELECT* FROM attributeset;";
        readonly public static string setAttributes = "SELECT * FROM attributeset_attribute where attributeSet_attributeSet_ID = {0} order by attribute_attribute_ID;";
        readonly public static string attribute = "SELECT * FROM attribute order by attribute_ID;";
        readonly public static string attributeValues = "SELECT * FROM attributevalue where attribute_attribute_ID = {0} order by val_value;";
        readonly public static string setAttributedata = "SELECT* FROM attributeset_attribute sa join attributeset ats on sa.attributeSet_attributeSet_ID = ats.attributeSet_ID join attribute a on sa.attribute_attribute_ID = a.attribute_ID where ats.attributeSet_ID = '{0}';";


        readonly public static string set_ID = "SELECT attributeSet_ID FROM attributeset where set_name = '{0}';";
        readonly public static string att_ID = "SELECT attribute_ID FROM attribute where att_name = '{0}';";
        readonly public static string attVal_ID = "SELECT attributeValue_ID FROM attributevalue where val_value = '{0}';";
    
        readonly public static string insProduct = "INSERT INTO product (product_ID ,pro_name, pro_description, pro_price, pro_stock, attributeSet_attributeSet_ID) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');";
        readonly public static string insProductAttribute = "INSERT INTO product_attributes (product_product_ID, attributeValue_attributeValue_ID, attributeSet_attributeSet_ID, attribute_attribute_ID) VALUES ('{0}', '{1}', '{2}', '{3}');";

        readonly public static string upProduct = "UPDATE product SET pro_name = '{0}', pro_description = '{1}', pro_price = '{2}', pro_stock = '{3}' WHERE (product_ID = '{4}');";
        readonly public static string upProductAtt = "UPDATE product_attributes SET attributeValue_attributeValue_ID = '{0}' WHERE (product_product_ID = '{1}' and attribute_attribute_ID ='{2}');";

        readonly public static string delProduct = "DELETE FROM product WHERE(product_ID = '{0}');";
        readonly public static string delProductAtt = "DELETE FROM product_attributes WHERE(product_product_ID = '{0}');";

        //=================================================
        //=================== Orders ======================
        //=================================================
        readonly public static string buy = "SELECT b.buy_ID as 'Order ID', p.pro_name as 'Product', s.sup_name as 'Supplier', b.buy_price as 'Price',b.buy_date as 'date', b.buy_qty as 'Qty' FROM buy b join supplier s on b.supplier_supplier_ID = s.supplier_ID join product p on b.product_product_ID = p.product_ID;";
        readonly public static string sell = "SELECT s.sell_ID as 'Order ID', p.pro_name as 'Product', concat(cus_name,' ',c.cus_lastName)as 'Customer', s.sel_price as 'Price',s.sel_date as 'date', s.sel_qty as 'Qty' FROM sell s join customer c on s.customer_customer_ID = c.customer_ID join product p on s.product_product_ID = p.product_ID;";
        readonly public static string ordersCustomers = "SELECT customer_ID, concat(cus_name, ' ', cus_lastName) as name FROM mydb.customer;";
        readonly public static string ordersProducts = "SELECT product_ID, pro_name FROM mydb.product;";
        readonly public static string ordersSuppliers = "SELECT supplier_ID, sup_name FROM mydb.supplier;";

        readonly public static string sellData = "SELECT c.customer_ID, p.product_ID, s.sel_date FROM sell s join customer c on s.customer_customer_ID = c.customer_ID join product p on s.product_product_ID = p.product_ID where s.sell_ID = {0};";
        readonly public static string buyData = "SELECT s.supplier_ID, p.product_ID, b.buy_date FROM buy b join product p on b.product_product_ID = p.product_ID join supplier s on b.supplier_supplier_ID = s.supplier_ID where b.Buy_ID = {0};";

        readonly public static string insBuy = "INSERT INTO buy(Buy_ID, product_product_ID, supplier_supplier_ID, buy_price, buy_date, buy_qty) VALUES ( {0},{1},{2},{3},'{4}',{5});";
        readonly public static string insSell = "INSERT INTO sell(sell_ID, customer_customer_ID, product_product_ID, sel_price, sel_date, sel_qty) VALUES ({0},{1},{2},{3},'{4}',{5});";

        readonly public static string upSell = "UPDATE sell SET sel_price = {0}, sel_date = '{1}', sel_qty = {2} WHERE sell_ID = {3};";
        readonly public static string upBuy = "UPDATE buy SET buy_price = {0}, buy_date = '{1}', buy_qty = {2} WHERE Buy_ID = {3};";

        readonly public static string delSell = "DELETE FROM sell WHERE sell_ID = {0};";
        readonly public static string delBuy =  "DELETE FROM buy WHERE Buy_ID = {0};";

        //=================================================
        //================== Customers ====================
        //=================================================

        readonly public static string customers = "SELECT c.customer_ID as 'ID', concat(c.cus_name ,' ',c.cus_lastName) as 'Name', c.cus_telephone as 'Telephone', c.cus_TC as 'TC Number', c.cus_adress as 'Adress', p.prov_name as 'Province', d.dis_name as 'District'  FROM customer c join province p on c.province_province_ID = p.province_ID join district d on c.district_district_ID = d.district_ID;";
        readonly public static string customersProvince = "SELECT * FROM province order by province_ID ;";
        readonly public static string customersDistrict = "SELECT * FROM district where province_province_ID = {0} order by district_ID;";
        readonly public static string customerData = "SELECT p.province_ID, d.district_ID, c.cus_name, c.cus_lastName FROM customer c join province p on c.province_province_ID = p.province_ID join district d on c.district_district_ID = d.district_ID where c.customer_ID = {0};";



        readonly public static string insCustomer = "INSERT INTO customer (customer_ID, cus_name, cus_lastName, cus_telephone, cus_TC, cus_adress, province_province_ID, district_district_ID) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');";
        readonly public static string upCustomer = "UPDATE customer SET cus_name = '{0}', cus_lastName = '{1}', cus_telephone = {2}, cus_TC = {3}, cus_adress = '{4}', province_province_ID = {5}, district_district_ID = {6} WHERE(customer_ID = {7} );";
        readonly public static string delCustomer = "DELETE FROM customer WHERE (customer_ID = {0});";

        //=================================================
        //================== Suppliers ====================
        //=================================================

        readonly public static string suppliers = "SELECT s.supplier_ID as 'ID', s.sup_name 'Name', s.sup_telephone as 'Telephone', s.sup_adress as 'Adress', p.prov_name as 'Province', d.dis_name as 'District' FROM supplier s join province p on s.province_province_ID = p.province_ID join district d on s.district_district_ID = d.district_ID;";
        readonly public static string suppliersProvince = "SELECT * FROM province order by province_ID ;";
        readonly public static string suppliersDistrict = "SELECT * FROM district where province_province_ID = {0} order by district_ID;";
        readonly public static string supplierData = "SELECT p.province_ID, d.district_ID FROM supplier s join province p on s.province_province_ID = p.province_ID join district d on s.district_district_ID = d.district_ID where s.supplier_ID = {0};";


        readonly public static string insSupplier = "INSERT INTO supplier (supplier_ID, sup_name, sup_telephone, sup_adress, province_province_ID, district_district_ID) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');";
        readonly public static string upSupplier = "UPDATE supplier SET sup_name = '{0}', sup_telephone = {1}, sup_adress = '{2}', province_province_ID = {3}, district_district_ID = {4} WHERE(supplier_ID = {5} );";
        readonly public static string delSuplier = "DELETE FROM supplier WHERE (supplier_ID = {0});";

        //=================================================
        //================== Suppliers ====================
        //=================================================
        readonly public static string incomes = "SELECT i.incomes_ID as 'ID', i.inc_description as 'Description', i.inc_amount as 'Amount', a.act_name as 'Activity Type' FROM incomes i join activity a on i.activity_activity_ID = a.activity_ID;";
        readonly public static string incomesType = "SELECT i.incomes_ID as 'ID', i.inc_description as 'Description', i.inc_amount as 'Amount', a.act_name as 'Activity Type' FROM incomes i join activity a on i.activity_activity_ID = a.activity_ID where i.activity_activity_ID = {0};";
        readonly public static string incomesData = "SELECT a.activity_ID FROM incomes i join activity a on i.activity_activity_ID = a.activity_ID where i.incomes_ID ={0};";
        readonly public static string delIncome = "DELETE FROM incomes WHERE (incomes_ID = {0});";


        readonly public static string expenses = "SELECT e.expenses_ID as 'ID', e.exp_description as 'Description', e.exp_amount as 'Amount', a.act_name as 'Activity Type' FROM expenses e join activity a on e.activity_activity_ID = a.activity_ID;";
        readonly public static string expensesType = "SELECT e.expenses_ID as 'ID', e.exp_description as 'Description', e.exp_amount as 'Amount', a.act_name as 'Activity Type' FROM expenses e join activity a on e.activity_activity_ID = a.activity_ID where e.activity_activity_ID = {0};";
        readonly public static string expensesData = "SELECT a.activity_ID FROM expenses e join activity a on e.activity_activity_ID = a.activity_ID where e.expenses_ID ={0};";
        readonly public static string delExpense = "DELETE FROM expenses WHERE (expenses_ID = {0});";


        readonly public static string activity = "SELECT activity_ID ,act_name FROM mydb.activity where activityType_activityType_ID ={0};";

        readonly public static string insIncome = "INSERT INTO incomes (incomes_ID, inc_description, inc_amount, activity_activity_ID ,activityType_activityType_ID) VALUES ({0},'{1}',{2},{3},{4});";
        readonly public static string insExpense = "INSERT INTO expenses (expenses_ID, exp_description, exp_amount, activity_activity_ID ,activityType_activityType_ID) VALUES ({0},'{1}',{2},{3},{4});";

    }

}
