using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTYS_Mobilay_Magazasi
{
    class Queries
    {
        readonly public static string products = "select p.product_ID, p.pro_name,pro_description,pro_price,pro_stock, ats.set_name from product p join attributeset ats on p.attributeSet_attributeSet_ID = ats.attributeSet_ID;";
        readonly public static string productsAttributes = "select att.att_name,av.val_value from product_attributes pa join product p on pa.product_product_ID = p.product_ID join attributeset ats on pa.attributeSet_attributeSet_ID = ats.attributeSet_ID join attribute att on pa.attribute_attribute_ID = att.attribute_ID join attributevalue av on pa.attributeValue_attributeValue_ID = av.attributeValue_ID where p.product_ID = {0};";
        readonly public static string attributeSet = "SELECT* FROM mydb.attributeset;";
        readonly public static string setAttributes = "SELECT * FROM mydb.attributeset_attribute where attributeSet_attributeSet_ID = {0} order by attribute_attribute_ID;";
        readonly public static string attribute = "SELECT * FROM mydb.attribute order by attribute_ID;";
        readonly public static string attributeValues = "SELECT * FROM mydb.attributevalue where attribute_attribute_ID = {0} order by val_value;";
    }
}
