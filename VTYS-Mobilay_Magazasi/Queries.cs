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
        readonly public static string attributeSet = "SELECT* FROM mydb.attributeset;";
        readonly public static string setAttributes = "SELECT * FROM mydb.attributeset_attribute where attributeSet_attributeSet_ID = {0} order by attribute_attribute_ID;";
        readonly public static string attribute = "SELECT * FROM mydb.attribute order by attribute_ID;";
        readonly public static string attributeValues = "SELECT * FROM mydb.attributevalue where attribute_attribute_ID = {0} order by val_value;";

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

        //Admin Panel
        readonly public static string attributeSet2 = "SELECT attributeSet_ID as \"ID\", set_name as \"Name\" FROM mydb.attributeset order by ID;";
        readonly public static string insAttributeSet = "INSERT INTO attributeset (attributeSet_ID ,set_name) VALUES ('{0}', '{1}');";
        readonly public static string upAttributeset = "UPDATE attributeset SET set_name = '{0}' WHERE (attributeSet_ID = '{1}');";
        readonly public static string insAttribute = "INSERT INTO attribute (attribute_ID ,att_name) VALUES ('{0}', '{1}');";
        readonly public static string upAttribute = "UPDATE attribute SET att_name = '{0}' WHERE (attribute_ID = '{1}');";
        readonly public static string province = "SELECT province_ID as \"ID\", prov_name as \"Name\" FROM mydb.province order by ID;";
        readonly public static string insProvince = "INSERT INTO province (province_ID ,prov_name) VALUES ('{0}', '{1}');";
        readonly public static string upProvince = "UPDATE province SET prov_name = '{0}' WHERE (province_ID = '{1}');";
        readonly public static string attributeValues2 = "SELECT attributeValue_ID as \"ID\", val_value as \"Name\"	, a.att_name as \"Attribute\"  FROM mydb.attributevalue v Join mydb.attribute a on a.attribute_ID=v.attribute_attribute_ID order by ID;";
        readonly public static string insAttributeValue = "INSERT INTO attributevalue (attributeValue_ID ,val_value,attribute_attribute_ID) VALUES ('{0}','{1}',({2}));";
        readonly public static string attribute_id = "SELECT attribute_ID FROM mydb.attribute WHERE att_name = '{0}'";
        readonly public static string upAttributeValue = "UPDATE attributevalue SET val_value = '{0}',attribute_attribute_ID =({1}) WHERE (attributeValue_ID = '{2}');";

    }
}
