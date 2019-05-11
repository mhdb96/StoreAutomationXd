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
        readonly public static string products = "select p.product_ID as \"ID\", p.pro_name as \"Name\",pro_description as \"Description\",pro_price as \"Price\",pro_stock as \"Stock\", ats.set_name as \"Category\" from product p join attributeset ats on p.attributeSet_attributeSet_ID = ats.attributeSet_ID order by {0};";
        readonly public static string productsAttributes = "select att.att_name,av.val_value from product_attributes pa join product p on pa.product_product_ID = p.product_ID join attributeset ats on pa.attributeSet_attributeSet_ID = ats.attributeSet_ID join attribute att on pa.attribute_attribute_ID = att.attribute_ID join attributevalue av on pa.attributeValue_attributeValue_ID = av.attributeValue_ID where p.product_ID = {0};";

        readonly public static string productsFiltering = "SELECT p.product_ID as \"ID\", p.pro_name as \"Name\", pro_description as \"Description\", pro_price as \"Price\", pro_stock as \"Stock\", ats.set_name as \"Category\" FROM product_attributes pa join product p on pa.product_product_ID = p.product_ID join attributeset ats on pa.attributeSet_attributeSet_ID = ats.attributeSet_ID where ats.attributeSet_ID= {0} group by p.product_ID;";

        readonly public static string productsBasicFilter= "select p.product_ID as \"ID\", p.pro_name as \"Name\",pro_description as \"Description\",pro_price as \"Price\",pro_stock as \"Stock\", ats.set_name as \"Category\" from product p join attributeset ats on p.attributeSet_attributeSet_ID = ats.attributeSet_ID where {0} {1} {2};";
        readonly public static string productsBetweenFilter = "select p.product_ID as \"ID\", p.pro_name as \"Name\",pro_description as \"Description\",pro_price as \"Price\",pro_stock as \"Stock\", ats.set_name as \"Category\" from product p join attributeset ats on p.attributeSet_attributeSet_ID = ats.attributeSet_ID where {0} between {1} and {2};";
        readonly public static string productsSearch = "select p.product_ID as \"ID\", p.pro_name as \"Name\",pro_description as \"Description\",pro_price as \"Price\",pro_stock as \"Stock\", ats.set_name as \"Category\" from product p join attributeset ats on p.attributeSet_attributeSet_ID = ats.attributeSet_ID where pro_name LIKE '%{0}%';";

        readonly public static string attributeSet = "SELECT* FROM mydb.attributeset;";
        readonly public static string setAttributes = "SELECT * FROM mydb.attributeset_attribute where attributeSet_attributeSet_ID = {0} order by attribute_attribute_ID;";
        readonly public static string attribute = "SELECT * FROM mydb.attribute order by attribute_ID;";
        readonly public static string attributeValues = "SELECT * FROM mydb.attributevalue where attribute_attribute_ID = {0} order by val_value;";
        readonly public static string setAttributedata = "SELECT* FROM attributeset_attribute sa join attributeset ats on sa.attributeSet_attributeSet_ID = ats.attributeSet_ID join attribute a on sa.attribute_attribute_ID = a.attribute_ID where ats.attributeSet_ID = '{0}';";

        readonly public static string newID = "SELECT max({0}) FROM {1};";
        readonly public static string set_ID = "SELECT attributeSet_ID FROM mydb.attributeset where set_name = '{0}';";
        readonly public static string att_ID = "SELECT attribute_ID FROM mydb.attribute where att_name = '{0}';";
        readonly public static string attVal_ID = "SELECT attributeValue_ID FROM mydb.attributevalue where val_value = '{0}';";
    
        readonly public static string insProduct = "INSERT INTO product (product_ID ,pro_name, pro_description, pro_price, pro_stock, attributeSet_attributeSet_ID) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');";
        readonly public static string insProductAttribute = "INSERT INTO product_attributes (product_product_ID, attributeValue_attributeValue_ID, attributeSet_attributeSet_ID, attribute_attribute_ID) VALUES ('{0}', '{1}', '{2}', '{3}');";

        readonly public static string upProduct = "UPDATE product SET pro_name = '{0}', pro_description = '{1}', pro_price = '{2}', pro_stock = '{3}' WHERE (product_ID = '{4}');";
        readonly public static string upProductAtt = "UPDATE product_attributes SET attributeValue_attributeValue_ID = '{0}' WHERE (product_product_ID = '{1}' and attribute_attribute_ID ='{2}');";

        readonly public static string delProduct = "DELETE FROM product WHERE(product_ID = '{0}');";
        readonly public static string delProductAtt = "DELETE FROM product_attributes WHERE(product_product_ID = '{0}');";

    }
}
