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
        readonly public static string attributeValues2 = "SELECT attribute_ID as \"ID\" ,att_name as \"Name\" FROM mydb.attribute;";
        readonly public static string insAttributeValue = "INSERT INTO attributevalue (attributeValue_ID ,val_value,attribute_attribute_ID) VALUES ('{0}','{1}',{2});";
        readonly public static string upAttributeValue = "UPDATE attributevalue SET val_value = '{0}',attribute_attribute_ID ={1} WHERE (attributeValue_ID = '{2}');";
        readonly public static string attributevalueId = "SELECT attributeValue_ID as \"ID\" , val_value as \"Name\" FROM attributevalue where attribute_attribute_ID={0};";
        readonly public static string department = "SELECT department_ID as \"ID\", dep_name as \"Name\" FROM mydb.department order by ID;";
        readonly public static string insDepartment = "INSERT INTO department (department_ID ,dep_name) VALUES ('{0}','{1}');";
        readonly public static string upDepartment = "UPDATE department SET dep_name = '{0}' WHERE (department_ID = '{1}');";
        readonly public static string departmentLike = "SELECT department_ID as \"ID\", dep_name as \"Name\" FROM mydb.department WHERE dep_name LIKE '%{0}%' order by ID;";
        readonly public static string attributeValueLike = "SELECT attribute_ID as \"ID\", att_name as \"Name\" FROM mydb.attribute WHERE att_name LIKE '%{0}%' order by ID;";
        readonly public static string provinceLike = "SELECT province_ID as \"ID\", prov_name as \"Name\" FROM mydb.province WHERE prov_name LIKE '%{0}%' order by ID;";
        readonly public static string attributeLike = "SELECT attribute_ID as \"ID\", att_name as \"Name\" FROM mydb.attribute WHERE att_name LIKE '%{0}%' order by ID;";
        readonly public static string attributeSetLike = "SELECT attributeSet_ID as \"ID\", set_name as \"Name\" FROM mydb.attributeset WHERE set_name LIKE '%{0}%' order by ID;";
        readonly public static string districtId = "SELECT district_ID as \"ID\" , dis_ID as \"Name\" FROM district  where province_province_ID={0};";
        readonly public static string insDistrict = "INSERT INTO district (district_ID ,dis_ID,province_province_ID) VALUES ('{0}','{1}',{2});";
        readonly public static string upDistrict = "UPDATE district SET dis_ID = '{0}',province_province_ID ={1} WHERE (district_ID = '{2}');";
        readonly public static string employee = "SELECT e.employee_ID, e.emp_name , e.emp_lasName,e.emp_TC,e.emp_telephone,e.emp_adress, d.dis_ID, p.prov_name , de.dep_name, e.emp_salary FROM mydb.employee e JOIN district d on d.district_ID=e.district_district_ID JOIN province p on p.province_ID=e.province_province_ID JOIN department de on de.department_ID=e.department_department_ID;";
        readonly public static string districtProvince = "SELECT * FROM district where province_province_ID = {0} order by district_ID;";
        readonly public static string insEmployee = "INSERT INTO employee (employee_ID ,emp_name,emp_lasName,emp_TC,emp_telephone,emp_adress,district_district_ID,province_province_ID,department_department_ID,emp_salary) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}');";
        readonly public static string upEmployee = "UPDATE employee SET emp_name= '{0}',emp_lasName= '{1}',emp_TC= '{2}',emp_telephone= '{3}',emp_adress= '{4}',district_district_ID= '{5}',province_province_ID= '{6}',department_department_ID= '{7}',emp_salary= '{8}' WHERE employee_ID='{9}';";

        readonly public static string province2 = "SELECT * FROM province order by province_ID ;";
        readonly public static string employeeLike = "SELECT e.employee_ID, e.emp_name , e.emp_lasName,e.emp_TC,e.emp_telephone,e.emp_adress, d.dis_ID, p.prov_name , de.dep_name, e.emp_salary FROM mydb.employee e JOIN district d on d.district_ID=e.district_district_ID JOIN province p on p.province_ID=e.province_province_ID JOIN department de on de.department_ID=e.department_department_ID WHERE e.emp_name LIKE '%{0}%';";
        readonly public static string activityType = "SELECT activityType_ID as \"ID\" ,actty_name as \"Name\" FROM mydb.activitytype;";
        readonly public static string activityId = "SELECT activity_ID as \"ID\" , act_name as \"Name\" FROM activity where activityType_activityType_ID={0};";
        readonly public static string activity = "SELECT * FROM mydb.activity order by activity_ID;";
        readonly public static string insActivityType = "INSERT INTO activity (activity_ID ,act_name,activityType_activityType_ID) VALUES ('{0}','{1}',{2});";
        readonly public static string upActivityType = "UPDATE activity SET act_name = '{0}',activityType_activityType_ID ={1} WHERE (activity_ID = '{2}');";
        readonly public static string activityTypeLike = "SELECT activityType_ID as \"ID\", actty_name as \"Name\" FROM mydb.activitytype WHERE actty_name LIKE '%{0}%' order by ID;";

        readonly public static string delAttributeSet = "DELETE FROM attributeset WHERE (attributeSet_ID = {0});";
        readonly public static string delAttributeSet_attribute = "DELETE FROM attributeset_attribute WHERE (attributeSet_attributeSet_ID = {0});";
        readonly public static string delAttribute = "DELETE FROM attribute  WHERE (attribute_ID = {0});";
        readonly public static string delAttributeSet_attribute2 = "DELETE FROM attributeset_attribute WHERE (attribute_attribute_ID = {0});";
        readonly public static string delAttributeValue = "DELETE FROM attributevalue WHERE (attribute_attribute_ID = {0});";
        readonly public static string delAttributeValue2 = "DELETE FROM attributevalue WHERE (attributeValue_ID = {0});";

        readonly public static string delProvince = "DELETE FROM province WHERE (province_ID = {0});";
        readonly public static string delDistrict = "DELETE FROM district WHERE (district_ID = {0});";
        readonly public static string delDistrict2 = "DELETE FROM district WHERE (province_province_ID = {0});";

        readonly public static string delEmployee = "DELETE FROM employee WHERE (employee_ID = {0});";

        readonly public static string delActivity = "DELETE FROM activity WHERE (activity_ID = {0});";

        readonly public static string delDepartment = "DELETE FROM department WHERE (department_ID = {0});";

        readonly public static string attribute2 = "SELECT attribute_ID as \"ID\", att_name as \"Name\" FROM mydb.attribute order by attribute_ID;";
        readonly public static string employee2 = "SELECT e.employee_ID as \"ID\", e.emp_name  as \"Name\", e.emp_lasName as \"Last Name\",e.emp_TC as \"TC\",e.emp_telephone as \"Tel\",e.emp_adress as \"Adress\", d.dis_ID as \"District\", p.prov_name  as \"Province\", de.dep_name as \"Department\", e.emp_salary  as \"Salary\" FROM mydb.employee e JOIN district d on d.district_ID=e.district_district_ID JOIN province p on p.province_ID=e.province_province_ID JOIN department de on de.department_ID=e.department_department_ID;";

    }
}
