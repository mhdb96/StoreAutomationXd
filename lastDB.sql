-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: mydb
-- ------------------------------------------------------
-- Server version	8.0.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `activity`
--

DROP TABLE IF EXISTS `activity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `activity` (
  `activity_ID` int(11) NOT NULL AUTO_INCREMENT,
  `act_name` varchar(45) NOT NULL,
  `activityType_activityType_ID` int(11) NOT NULL,
  PRIMARY KEY (`activity_ID`),
  KEY `fk_activity_activityType1_idx` (`activityType_activityType_ID`),
  CONSTRAINT `fk_activity_activityType1` FOREIGN KEY (`activityType_activityType_ID`) REFERENCES `activitytype` (`activityType_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activity`
--

LOCK TABLES `activity` WRITE;
/*!40000 ALTER TABLE `activity` DISABLE KEYS */;
INSERT INTO `activity` VALUES (1,'sell',1),(2,'promo',1),(3,'buy',2),(4,'fatura',2);
/*!40000 ALTER TABLE `activity` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `activitytype`
--

DROP TABLE IF EXISTS `activitytype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `activitytype` (
  `activityType_ID` int(11) NOT NULL AUTO_INCREMENT,
  `actty_name` varchar(45) NOT NULL,
  PRIMARY KEY (`activityType_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activitytype`
--

LOCK TABLES `activitytype` WRITE;
/*!40000 ALTER TABLE `activitytype` DISABLE KEYS */;
INSERT INTO `activitytype` VALUES (1,'income'),(2,'expense');
/*!40000 ALTER TABLE `activitytype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attribute`
--

DROP TABLE IF EXISTS `attribute`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `attribute` (
  `attribute_ID` int(11) NOT NULL AUTO_INCREMENT,
  `att_name` varchar(45) NOT NULL,
  PRIMARY KEY (`attribute_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attribute`
--

LOCK TABLES `attribute` WRITE;
/*!40000 ALTER TABLE `attribute` DISABLE KEYS */;
INSERT INTO `attribute` VALUES (1,'color'),(2,'back style'),(3,'material'),(4,'kapi sayisi'),(5,'cekmece sayisi'),(6,'teker'),(7,'kenar');
/*!40000 ALTER TABLE `attribute` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attributeset`
--

DROP TABLE IF EXISTS `attributeset`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `attributeset` (
  `attributeSet_ID` int(11) NOT NULL AUTO_INCREMENT,
  `set_name` varchar(45) NOT NULL,
  PRIMARY KEY (`attributeSet_ID`),
  UNIQUE KEY `set_name_UNIQUE` (`set_name`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attributeset`
--

LOCK TABLES `attributeset` WRITE;
/*!40000 ALTER TABLE `attributeset` DISABLE KEYS */;
INSERT INTO `attributeset` VALUES (4,'Bedside table'),(1,'bedstead'),(5,'Chest of drawer'),(6,'Mattresses'),(2,'table'),(3,'Wardrobe');
/*!40000 ALTER TABLE `attributeset` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attributeset_attribute`
--

DROP TABLE IF EXISTS `attributeset_attribute`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `attributeset_attribute` (
  `attributeSet_attribute_ID` int(11) NOT NULL AUTO_INCREMENT,
  `attributeSet_attributeSet_ID` int(11) NOT NULL,
  `attribute_attribute_ID` int(11) NOT NULL,
  PRIMARY KEY (`attributeSet_attribute_ID`),
  KEY `fk_attributeSet_has_attribute_attribute1_idx` (`attribute_attribute_ID`),
  KEY `fk_attributeSet_has_attribute_attributeSet1_idx` (`attributeSet_attributeSet_ID`),
  CONSTRAINT `fk_attributeSet_has_attribute_attribute1` FOREIGN KEY (`attribute_attribute_ID`) REFERENCES `attribute` (`attribute_ID`),
  CONSTRAINT `fk_attributeSet_has_attribute_attributeSet1` FOREIGN KEY (`attributeSet_attributeSet_ID`) REFERENCES `attributeset` (`attributeSet_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attributeset_attribute`
--

LOCK TABLES `attributeset_attribute` WRITE;
/*!40000 ALTER TABLE `attributeset_attribute` DISABLE KEYS */;
INSERT INTO `attributeset_attribute` VALUES (1,1,1),(2,1,2),(3,1,3),(4,2,1),(5,2,3),(6,3,1),(7,3,3),(8,3,4),(9,4,1),(10,4,3),(11,4,5),(12,4,6),(13,4,7),(14,5,1),(15,5,3),(16,5,5),(17,5,6),(18,5,7),(19,6,1),(20,6,3);
/*!40000 ALTER TABLE `attributeset_attribute` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attributevalue`
--

DROP TABLE IF EXISTS `attributevalue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `attributevalue` (
  `attributeValue_ID` int(11) NOT NULL AUTO_INCREMENT,
  `val_value` varchar(45) NOT NULL,
  `attribute_attribute_ID` int(11) NOT NULL,
  PRIMARY KEY (`attributeValue_ID`),
  KEY `fk_attributeValue_attribute1_idx` (`attribute_attribute_ID`),
  CONSTRAINT `fk_attributeValue_attribute1` FOREIGN KEY (`attribute_attribute_ID`) REFERENCES `attribute` (`attribute_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attributevalue`
--

LOCK TABLES `attributevalue` WRITE;
/*!40000 ALTER TABLE `attributevalue` DISABLE KEYS */;
INSERT INTO `attributevalue` VALUES (1,'red',1),(2,'blue',1),(3,'green',1),(4,'Metal',3),(5,'Wood',3),(6,'Panel',2),(7,'Wingback',2),(8,'1',4),(9,'2',4),(10,'3',4),(11,'1',5),(12,'2',5),(13,'3',5),(14,'4',5),(15,'var',6),(16,'yok',6),(17,'koseli',7),(18,'yuvarlak',7);
/*!40000 ALTER TABLE `attributevalue` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `buy`
--

DROP TABLE IF EXISTS `buy`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `buy` (
  `Buy_ID` int(11) NOT NULL AUTO_INCREMENT,
  `product_product_ID` int(11) NOT NULL,
  `supplier_supplier_ID` int(11) NOT NULL,
  `buy_price` decimal(8,2) NOT NULL,
  `buy_date` datetime NOT NULL,
  `buy_qty` int(11) NOT NULL,
  PRIMARY KEY (`Buy_ID`),
  KEY `fk_product_has_supplier_supplier1_idx` (`supplier_supplier_ID`),
  KEY `fk_product_has_supplier_product1_idx` (`product_product_ID`),
  CONSTRAINT `fk_product_has_supplier_product1` FOREIGN KEY (`product_product_ID`) REFERENCES `product` (`product_ID`),
  CONSTRAINT `fk_product_has_supplier_supplier1` FOREIGN KEY (`supplier_supplier_ID`) REFERENCES `supplier` (`supplier_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `buy`
--

LOCK TABLES `buy` WRITE;
/*!40000 ALTER TABLE `buy` DISABLE KEYS */;
INSERT INTO `buy` VALUES (1,12,1,10.00,'2019-05-01 22:11:22',1),(2,5,2,1.00,'2019-05-12 12:00:00',1),(3,7,3,10.00,'2019-05-12 17:55:43',1),(4,6,4,3.00,'2019-05-12 19:34:56',4),(5,6,9,1.00,'2019-05-12 19:35:04',1);
/*!40000 ALTER TABLE `buy` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `customer` (
  `customer_ID` int(11) NOT NULL AUTO_INCREMENT,
  `cus_name` varchar(45) NOT NULL,
  `cus_lastName` varchar(45) NOT NULL,
  `cus_telephone` varchar(10) NOT NULL,
  `cus_TC` varchar(11) NOT NULL,
  `cus_adress` varchar(255) NOT NULL,
  `province_province_ID` int(11) NOT NULL,
  `district_district_ID` int(11) NOT NULL,
  PRIMARY KEY (`customer_ID`),
  UNIQUE KEY `TC_UNIQUE` (`cus_TC`),
  KEY `fk_customer_province1_idx` (`province_province_ID`),
  KEY `fk_customer_district1_idx` (`district_district_ID`),
  CONSTRAINT `fk_customer_district1` FOREIGN KEY (`district_district_ID`) REFERENCES `district` (`district_ID`),
  CONSTRAINT `fk_customer_province1` FOREIGN KEY (`province_province_ID`) REFERENCES `province` (`province_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (1,'muhammed','bedavi','5318861290','99455434567','gyasuidfh asd fuas',1,1),(2,'onur','kantar','5437782389','45977893490','dsjhf jhsdjfhjsdh f',1,2),(3,'Ozan','Metin','0741369854','45698741568','istanbul',1,9),(4,'Hasan','Tas','0756998753','45468723687','etiler',2,15),(5,'Leyla','Genc','0456578921','46545648752','esenler',1,7),(6,'Yunus','Basaran','4512547877','56874132789','istanbul',3,27),(7,'Ezgi','Patar','7895411248','77755424966','nisantasi',1,8),(8,'Asli','Sucu','7521668754','32475694217','beylikduzu',1,4),(9,'Emir','Diker','8854212147','24548752424','kavacık',1,7),(10,'Beyza','Ozcan','7562177998','12475662136','sisli',3,24),(12,'Will','Turner','0456789986','54786858756','karayipler',1,5),(13,'Selim','Sevinc','5329957838','99999999999','sdfsdfsd fsd f sdfsdf sd fsd',1,5);
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `department` (
  `department_ID` int(11) NOT NULL AUTO_INCREMENT,
  `dep_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`department_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (1,'Satıs'),(2,'Teslimat'),(3,'Montaj'),(4,'Temizlik'),(5,'Depo'),(6,'Yonetim');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `district`
--

DROP TABLE IF EXISTS `district`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `district` (
  `district_ID` int(11) NOT NULL AUTO_INCREMENT,
  `dis_name` varchar(45) NOT NULL,
  `province_province_ID` int(11) NOT NULL,
  PRIMARY KEY (`district_ID`),
  KEY `fk_district_province1_idx` (`province_province_ID`),
  CONSTRAINT `fk_district_province1` FOREIGN KEY (`province_province_ID`) REFERENCES `province` (`province_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `district`
--

LOCK TABLES `district` WRITE;
/*!40000 ALTER TABLE `district` DISABLE KEYS */;
INSERT INTO `district` VALUES (1,'umraniye',1),(2,'fatih',1),(3,'Akyurt',2),(4,'Evren',2),(5,'Bagcilar',1),(6,'Bakirkoy',1),(7,'Kartal',1),(8,'Besiktas',1),(9,'Sisli',1),(10,'Kadikoy',1),(11,'Buca',2),(12,'Bornova',2),(13,'Konak',2),(14,'Karsiyaka',2),(15,'Torbali',2),(16,'Odemis',2),(17,'Bergama',2),(18,'Aliaga',2),(19,'Tire',2),(20,'Foca',2),(21,'Cankaya',3),(22,'Mamak',3),(23,'Sincan',3),(24,'Polatli',3),(25,'Cubuk',3),(26,'Beypazari',3),(27,'Bala',3),(28,'Ayas',3),(29,'Kalecik',3),(30,'Kizilcahamam',3),(31,'Adalar',1),(32,'Arnavutkoy',1),(33,'Atasehir',1),(34,'Avcilar',1);
/*!40000 ALTER TABLE `district` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `employee` (
  `employee_ID` int(11) NOT NULL AUTO_INCREMENT,
  `emp_name` varchar(45) NOT NULL,
  `emp_lasName` varchar(45) NOT NULL,
  `emp_TC` varchar(11) NOT NULL,
  `emp_telephone` varchar(11) NOT NULL,
  `emp_adress` varchar(255) NOT NULL,
  `district_district_ID` int(11) NOT NULL,
  `province_province_ID` int(11) NOT NULL,
  `department_department_ID` int(11) NOT NULL,
  `emp_salary` decimal(8,2) NOT NULL,
  PRIMARY KEY (`employee_ID`),
  UNIQUE KEY `emp_TC_UNIQUE` (`emp_TC`),
  KEY `fk_employee_district1_idx` (`district_district_ID`),
  KEY `fk_employee_province1_idx` (`province_province_ID`),
  KEY `fk_employee_department1_idx` (`department_department_ID`),
  CONSTRAINT `fk_employee_department1` FOREIGN KEY (`department_department_ID`) REFERENCES `department` (`department_ID`),
  CONSTRAINT `fk_employee_district1` FOREIGN KEY (`district_district_ID`) REFERENCES `district` (`district_ID`),
  CONSTRAINT `fk_employee_province1` FOREIGN KEY (`province_province_ID`) REFERENCES `province` (`province_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,'Kartal Yagiz','Deveci','23546897796','05477788566','sisli',3,1,6,10000.00),(2,'Onur','Kantar','12459635782','07863325864','kartal',7,1,6,9000.00),(3,'Muhammed','AlBadwieh','45726874253','06547522433','istanbul',10,1,6,12000.00),(4,'Kylo','Ren','95786425376','05479683566','coruscant',14,2,1,2500.00),(5,'Tony','Stark','78451232659','02358854168','new york',20,2,3,2200.00),(6,'Aleyna','Tilki','45689535247','03657896545','besiktas',13,2,4,1800.00),(7,'Anakin','Skywalker','12345698754','05417756871','mustafar',12,2,2,2000.00),(8,'Will','Smith','78658425751','03258869547','California',26,3,5,2400.00);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `expenses`
--

DROP TABLE IF EXISTS `expenses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `expenses` (
  `expenses_ID` int(11) NOT NULL AUTO_INCREMENT,
  `exp_description` varchar(45) DEFAULT NULL,
  `exp_amount` decimal(10,2) NOT NULL,
  `activity_activity_ID` int(11) NOT NULL,
  `activityType_activityType_ID` int(11) NOT NULL,
  PRIMARY KEY (`expenses_ID`),
  KEY `fk_expenses_activity1_idx` (`activity_activity_ID`),
  KEY `fk_expenses_activityType1_idx` (`activityType_activityType_ID`),
  CONSTRAINT `fk_expenses_activity1` FOREIGN KEY (`activity_activity_ID`) REFERENCES `activity` (`activity_ID`),
  CONSTRAINT `fk_expenses_activityType1` FOREIGN KEY (`activityType_activityType_ID`) REFERENCES `activitytype` (`activityType_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expenses`
--

LOCK TABLES `expenses` WRITE;
/*!40000 ALTER TABLE `expenses` DISABLE KEYS */;
INSERT INTO `expenses` VALUES (1,'elek fatura',400.00,4,2),(2,'alfemi buy',1000.00,3,2);
/*!40000 ALTER TABLE `expenses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `incomes`
--

DROP TABLE IF EXISTS `incomes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `incomes` (
  `incomes_ID` int(11) NOT NULL AUTO_INCREMENT,
  `inc_description` varchar(45) DEFAULT NULL,
  `inc_amount` decimal(10,2) NOT NULL,
  `activity_activity_ID` int(11) NOT NULL,
  `activityType_activityType_ID` int(11) NOT NULL,
  PRIMARY KEY (`incomes_ID`),
  KEY `fk_incomes_activity1_idx` (`activity_activity_ID`),
  KEY `fk_incomes_activityType1_idx` (`activityType_activityType_ID`),
  CONSTRAINT `fk_incomes_activity1` FOREIGN KEY (`activity_activity_ID`) REFERENCES `activity` (`activity_ID`),
  CONSTRAINT `fk_incomes_activityType1` FOREIGN KEY (`activityType_activityType_ID`) REFERENCES `activitytype` (`activityType_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `incomes`
--

LOCK TABLES `incomes` WRITE;
/*!40000 ALTER TABLE `incomes` DISABLE KEYS */;
INSERT INTO `incomes` VALUES (1,'satis',1100.00,1,1),(2,'pepsi promo',100.00,2,1),(3,'33',33.00,1,1);
/*!40000 ALTER TABLE `incomes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `product` (
  `product_ID` int(11) NOT NULL AUTO_INCREMENT,
  `pro_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `pro_description` text NOT NULL,
  `pro_price` decimal(8,2) NOT NULL,
  `pro_stock` int(11) NOT NULL,
  `attributeSet_attributeSet_ID` int(11) NOT NULL,
  PRIMARY KEY (`product_ID`),
  KEY `fk_product_attributeSet_idx` (`attributeSet_attributeSet_ID`),
  CONSTRAINT `fk_product_attributeSet` FOREIGN KEY (`attributeSet_attributeSet_ID`) REFERENCES `attributeset` (`attributeSet_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (4,'istikbal table','normal table',50.00,15,2),(5,'kelebek makyaj masasi','normal masa',100.00,20,2),(6,'istikbal gardrop','normal gardrop',200.00,25,3),(7,'alfemo yatak','normal yatak',150.00,10,6),(10,'alfemo bedside ','its a very good table',200.00,34,4),(12,'hamafa','yatak',77.00,77,1),(13,'1','1',1.00,1,1),(14,'1','1',1.00,1,1);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_attributes`
--

DROP TABLE IF EXISTS `product_attributes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `product_attributes` (
  `pa_ID` int(11) NOT NULL AUTO_INCREMENT,
  `product_product_ID` int(11) NOT NULL,
  `attributeValue_attributeValue_ID` int(11) NOT NULL,
  `attributeSet_attributeSet_ID` int(11) NOT NULL,
  `attribute_attribute_ID` int(11) NOT NULL,
  PRIMARY KEY (`pa_ID`),
  KEY `fkproduct_has_attributeValue_attributeValue1_idx` (`attributeValue_attributeValue_ID`),
  KEY `fkproduct_has_attributeValue_product1_idx` (`product_product_ID`),
  KEY `fkproduct_attributes_attributeSet1_idx` (`attributeSet_attributeSet_ID`),
  KEY `fkproduct_attributes_attribute1_idx` (`attribute_attribute_ID`) /*!80000 INVISIBLE */,
  CONSTRAINT `fk1_product_has_attributeValue_product1` FOREIGN KEY (`product_product_ID`) REFERENCES `product` (`product_ID`),
  CONSTRAINT `fk2_product_has_attributeValue_attributeValue1` FOREIGN KEY (`attributeValue_attributeValue_ID`) REFERENCES `attributevalue` (`attributeValue_ID`),
  CONSTRAINT `fk3_product_attributes_attributeSet1` FOREIGN KEY (`attributeSet_attributeSet_ID`) REFERENCES `attributeset` (`attributeSet_ID`),
  CONSTRAINT `fk4_product_attributes_attribute1` FOREIGN KEY (`attribute_attribute_ID`) REFERENCES `attribute` (`attribute_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_attributes`
--

LOCK TABLES `product_attributes` WRITE;
/*!40000 ALTER TABLE `product_attributes` DISABLE KEYS */;
INSERT INTO `product_attributes` VALUES (11,4,2,2,1),(12,4,5,2,3),(13,4,15,2,6),(14,4,17,2,7),(15,5,3,2,1),(16,5,5,2,3),(17,5,11,2,5),(18,5,16,2,6),(19,5,17,2,7),(20,6,1,3,1),(21,6,5,3,3),(22,6,9,3,4),(23,7,1,6,1),(24,7,5,6,3),(33,10,3,4,1),(34,10,5,4,3),(35,10,12,4,5),(36,10,15,4,6),(37,10,18,4,7),(41,12,1,1,1),(42,12,6,1,2),(43,12,4,1,3),(49,13,3,1,1),(50,13,6,1,2),(51,13,4,1,3),(52,14,3,1,1),(53,14,6,1,2),(54,14,4,1,3);
/*!40000 ALTER TABLE `product_attributes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `province`
--

DROP TABLE IF EXISTS `province`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `province` (
  `province_ID` int(11) NOT NULL AUTO_INCREMENT,
  `prov_name` varchar(45) NOT NULL,
  PRIMARY KEY (`province_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `province`
--

LOCK TABLES `province` WRITE;
/*!40000 ALTER TABLE `province` DISABLE KEYS */;
INSERT INTO `province` VALUES (1,'istanbul'),(2,'izmir'),(3,'ankara');
/*!40000 ALTER TABLE `province` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sell`
--

DROP TABLE IF EXISTS `sell`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sell` (
  `sell_ID` int(11) NOT NULL AUTO_INCREMENT,
  `customer_customer_ID` int(11) NOT NULL,
  `product_product_ID` int(11) NOT NULL,
  `sel_price` decimal(8,2) NOT NULL,
  `sel_date` datetime NOT NULL,
  `sel_qty` int(11) NOT NULL,
  PRIMARY KEY (`sell_ID`),
  KEY `fk_customer_has_product_product1_idx` (`product_product_ID`),
  KEY `fk_customer_has_product_customer1_idx` (`customer_customer_ID`),
  CONSTRAINT `fk_customer_has_product_customer1` FOREIGN KEY (`customer_customer_ID`) REFERENCES `customer` (`customer_ID`),
  CONSTRAINT `fk_customer_has_product_product1` FOREIGN KEY (`product_product_ID`) REFERENCES `product` (`product_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sell`
--

LOCK TABLES `sell` WRITE;
/*!40000 ALTER TABLE `sell` DISABLE KEYS */;
INSERT INTO `sell` VALUES (1,1,4,100.00,'2019-05-11 12:59:59',1),(3,3,7,20.00,'2019-05-15 17:58:55',2),(4,4,7,3.00,'2019-05-12 19:36:11',5),(5,4,7,1.00,'2019-05-12 19:36:16',1);
/*!40000 ALTER TABLE `sell` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `supplier` (
  `supplier_ID` int(11) NOT NULL AUTO_INCREMENT,
  `sup_name` varchar(45) NOT NULL,
  `sup_telephone` varchar(11) NOT NULL,
  `sup_adress` varchar(255) NOT NULL,
  `province_province_ID` int(11) NOT NULL,
  `district_district_ID` int(11) NOT NULL,
  PRIMARY KEY (`supplier_ID`),
  KEY `fk_supplier_province1_idx` (`province_province_ID`),
  KEY `fk_supplier_district1_idx` (`district_district_ID`),
  CONSTRAINT `fk_supplier_district1` FOREIGN KEY (`district_district_ID`) REFERENCES `district` (`district_ID`),
  CONSTRAINT `fk_supplier_province1` FOREIGN KEY (`province_province_ID`) REFERENCES `province` (`province_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier`
--

LOCK TABLES `supplier` WRITE;
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
INSERT INTO `supplier` VALUES (1,'Ikea','05474458633','tattoine',2,18),(2,'Bellona','05476698333','maslak',1,1),(3,'Yatas','08527538426','new york',2,16),(4,'Tekzen','03574156985','karayipler',3,21),(5,'Istikbal','35786542188','karayipler',2,11),(6,'Moda','35687123897','ankara',3,30),(7,'Englishhome','03568876524','ankara',3,28),(8,'Koctas','07536988544','ankara',3,25),(9,'Bambi','04566683274','istinye',1,6),(10,'Visko','05746682569','washington',2,13);
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-15 15:15:53
