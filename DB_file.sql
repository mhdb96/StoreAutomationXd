-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: pro
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
INSERT INTO `activity` VALUES (1,'Buy',1),(2,'Sell',2),(3,'Promo',1),(4,'Bill',1);
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
INSERT INTO `activitytype` VALUES (1,'Expenses'),(2,'Incomes');
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
INSERT INTO `attribute` VALUES (1,'Color'),(2,'Back Style'),(3,'Material'),(4,'Door Number'),(5,'Drawer Number'),(6,'Wheel'),(7,'Corner');
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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attributeset`
--

LOCK TABLES `attributeset` WRITE;
/*!40000 ALTER TABLE `attributeset` DISABLE KEYS */;
INSERT INTO `attributeset` VALUES (4,'Bedside Table'),(1,'Bedstead'),(5,'Chest of Drawer'),(6,'Mattresses'),(7,'Mirror'),(8,'Sofa'),(9,'Study Desk'),(2,'Table'),(3,'Wardrobe');
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
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attributeset_attribute`
--

LOCK TABLES `attributeset_attribute` WRITE;
/*!40000 ALTER TABLE `attributeset_attribute` DISABLE KEYS */;
INSERT INTO `attributeset_attribute` VALUES (6,3,1),(7,3,3),(8,3,4),(19,6,1),(20,6,3),(26,1,1),(27,1,2),(28,1,3),(29,2,1),(30,2,3),(31,4,1),(32,4,3),(33,4,5),(34,4,6),(35,4,7),(36,5,1),(37,5,3),(38,5,5),(39,5,6),(40,5,7),(41,7,1),(42,7,3),(43,7,7),(44,7,6),(45,8,1),(46,8,3),(47,9,1),(48,9,3),(49,9,7),(50,9,5);
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
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attributevalue`
--

LOCK TABLES `attributevalue` WRITE;
/*!40000 ALTER TABLE `attributevalue` DISABLE KEYS */;
INSERT INTO `attributevalue` VALUES (1,'Red',1),(2,'Blue',1),(3,'Green',1),(4,'Metal',3),(5,'Wood',3),(6,'Panel',2),(7,'Wingback',2),(8,'1',4),(9,'2',4),(10,'3',4),(11,'1',5),(12,'2',5),(13,'3',5),(14,'4',5),(15,'Yes',6),(16,'No',6),(17,'Edge',7),(18,'Round',7),(19,'White',1),(20,'Black',1),(21,'Brown',1),(22,'Pink',1),(23,'Beige',1),(24,'Leather',3),(25,'Fabric',3),(26,'4',4),(27,'5',4),(28,'6',4),(29,'Gray',1),(30,'Dark Orange',1),(31,'Jet Black',1);
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
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `buy`
--

LOCK TABLES `buy` WRITE;
/*!40000 ALTER TABLE `buy` DISABLE KEYS */;
INSERT INTO `buy` VALUES (1,12,1,10.00,'2019-05-01 22:11:22',2),(2,5,2,1.00,'2019-05-12 12:00:00',1),(3,7,3,10.00,'2019-05-12 17:55:43',1),(4,6,4,3.00,'2019-05-12 19:34:56',4),(5,6,9,1.00,'2019-05-12 19:35:04',1),(7,6,3,20.00,'2019-05-16 05:38:58',2),(8,6,2,2.00,'2019-05-16 05:39:47',2),(9,27,11,4000.00,'2019-05-16 21:49:36',10),(10,24,1,11.00,'2019-05-19 02:17:24',1),(11,6,1,1.00,'2019-05-19 03:13:27',1);
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
INSERT INTO `customer` VALUES (1,'Muhammed','Bedavi','5318861290','99455434567','gyasuidfh asd fuas',1,1),(2,'Onur','Kantar','5437782389','45977893490','dsjhf jhsdjfhjsdh f',1,2),(3,'Ozan','Metin','0741369854','45698741568','istanbul',1,9),(4,'Hasan','Tas','0756998753','45468723687','etiler',2,15),(5,'Leyla','Genc','0456578921','46545648752','esenler',1,7),(6,'Yunus','Basaran','4512547877','56874132789','istanbul',3,27),(7,'Ezgi','Patar','7895411248','77755424966','nisantasi',1,8),(8,'Asli','Sucu','7521668754','32475694217','beylikduzu',1,4),(9,'Emir','Diker','8854212147','24548752424','kavacık',1,7),(10,'Beyza','Ozcan','7562177998','12475662136','sisli',3,24),(12,'Will','Turner','0456789986','54786858756','karayipler',1,5),(13,'Selim','Sevinc','5329957838','99999999999','sdfsdfsd fsd f sdfsdf sd fsd',1,5);
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
INSERT INTO `district` VALUES (1,'Ümraniye',1),(2,'Fatih',1),(3,'Akyurt',2),(4,'Evren',2),(5,'Bagcilar',1),(6,'Bakirkoy',1),(7,'Kartal',1),(8,'Besiktas',1),(9,'Sisli',1),(10,'Kadikoy',1),(11,'Buca',2),(12,'Bornova',2),(13,'Konak',2),(14,'Karsiyaka',2),(15,'Torbali',2),(16,'Odemis',2),(17,'Bergama',2),(18,'Aliaga',2),(19,'Tire',2),(20,'Foca',2),(21,'Cankaya',3),(22,'Mamak',3),(23,'Sincan',3),(24,'Polatli',3),(25,'Cubuk',3),(26,'Beypazari',3),(27,'Bala',3),(28,'Ayas',3),(29,'Kalecik',3),(30,'Kizilcahamam',3),(31,'Adalar',1),(32,'Arnavutkoy',1),(33,'Atasehir',1),(34,'Avcilar',1);
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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,'Kartal Yagiz','Deveci','23546897796','05477788566','sisli',3,1,6,10000.00),(2,'Onur','Kantar','12459635782','07863325864','kartal',7,1,6,9000.00),(3,'Muhammed','Bedavi','45726874253','06547522433','istanbul',10,1,6,12000.00),(4,'Kylo','Ren','95786425376','05479683566','coruscant',14,2,1,2500.00),(5,'Tony','Stark','78451232659','02358854168','new york',20,2,3,2200.00),(6,'Aleyna','Tilki','45689535247','03657896545','besiktas',13,2,4,1800.00),(7,'Anakin','Skywalker','12345698754','05417756871','mustafar',12,2,2,2000.00),(8,'Will','Smith','78658425751','03258869547','California',26,3,5,2400.00),(9,'Maxwell','Andrew','56987564462','0101010101','New Jersey',33,1,3,2100.00),(10,'Morgan','Freeman','45454545455','7537537537','Washington',24,3,1,3000.00);
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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expenses`
--

LOCK TABLES `expenses` WRITE;
/*!40000 ALTER TABLE `expenses` DISABLE KEYS */;
INSERT INTO `expenses` VALUES (1,'elek fatura',400.00,4,2),(2,'alfemi buy',1000.00,3,2),(6,'istikbal gardrop',4.00,1,1),(7,'Alfemo Kids&Teens VINTAGE MODE Study Desk',40000.00,1,1),(8,'Alfemo ALACATI PLUS Sofa',11.00,1,1),(9,'İstikbal Gardrop',1.00,1,1);
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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `incomes`
--

LOCK TABLES `incomes` WRITE;
/*!40000 ALTER TABLE `incomes` DISABLE KEYS */;
INSERT INTO `incomes` VALUES (2,'pepsi promo',100.00,2,1),(5,'istikbal table',200.00,2,2),(6,'Alfemo QUEEN Sofa',900.00,2,2),(7,'Alfemo Kids&Teens VINTAGE MODE Study Desk',410.00,2,2),(8,'Alfemo JULIEN Bedstead Queen Size ',13500.00,2,2),(9,'Alfemo ESCUDA Chest of Drawer',1.00,2,2);
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
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (5,'Kelebek Makyaj Masasi','normal masaa',100.00,20,2),(6,'İstikbal Gardrop','normal gardrop',200.00,30,3),(7,'Alfemo Yatak','normal yatak',150.00,10,6),(10,'Alfemo Bedside ','its a very good table',200.00,34,4),(12,'Hamafa','yatak',77.00,78,1),(13,'Alfemo ALACATI Bedstead King Size','Assembly Required, Built-in Lighting, Drawers, Eco-Friendly, Glass Doors, Laser Cutting, Shelving, Slow Motion, Wardrobe',385.44,5,1),(14,'Alfemo ALACATI 6D Wardrobe','Assembly Required, Built-in Lighting, Drawers, Eco-Friendly, Glass Doors, Laser Cutting, Shelving, Slow Motion, Wardrobe',975.12,5,3),(15,'Alfemo ESCUDA Bedroom Set','Alfemo has designed collection indepented from everything and all the time: Escuda! Modern and urban touches invigorate in Escuda’s technological and ergonomic details. Escuda has prepared for those who choose to give different perspectives on life',1695.60,16,3),(16,'Alfemo ESCUDA Chest of Drawer','Alfemo has designed collection indepented from everything and all the time: Escuda! Modern and urban touches invigorate in Escuda’s technological and ergonomic details. Escuda has prepared for those who choose to give different perspectives on life',434.16,14,5),(17,'Alfemo ESCUDA Chest of Drawer Mirror','Alfemo has designed collection indepented from everything and all the time: Escuda! Modern and urban touches invigorate in Escuda’s technological and ergonomic details. Escuda has prepared for those who choose to give different perspectives on life',127.92,13,7),(18,'Alfemo JULIEN Bedstead Queen Size ','The perfect centerpiece for your bedroom! The low profile headboard and footboard, designed with square tufted detailing give the piece a modern look and feel. Its beautiful linen upholstery and thick cushioned padding will make your room look like a luxurious and comfortable haven to sleep in. The bed’s clean square profile is built with multiple wooden slats for support and durability and does not require a box spring',384.00,16,1),(19,'Alfemo SIENA Bedside Table Set','Charm of the white color',128.40,12,4),(20,'Alfemo MARSILIA Sofa','Alfemo Sofa Sets are an alternative for every single style.. From modern designs to classic deatails, all types of sofa sets are bringing elegancy to your living rooms. Sofa sets designed with unique details become most favorite furnitures of your houses',792.96,11,8),(21,'Alfemo ALACATI Sofa','Alfemo Sofa Sets are an alternative for every single style.. From modern designs to classic deatails, all types of sofa sets are bringing elegancy to your living rooms. Sofa sets designed with unique details become most favorite furnitures of your houses.',1176.96,30,8),(22,'Alfemo NEPTUNE Sofa','Alfemo Sofa Sets are an alternative for every single style.. From modern designs to classic deatails, all types of sofa sets are bringing elegancy to your living rooms. Sofa sets designed with unique details become most favorite furnitures of your houses.',3787.19,22,8),(23,'Alfemo QUEEN Sofa','Alfemo QUEEN Sofa',915.84,16,8),(24,'Alfemo ALACATI PLUS Sofa','Alfemo ALACATI PLUS Sofa',1176.96,36,8),(25,'Alfemo Disney FROZEN Study Desk','Alfemo Disney FROZEN Study Desk',416.40,3,9),(26,'Eksen LOTUS COUPLE Study Desk','Eksen LOTUS COUPLE Study Desk',86.94,16,9),(27,'Alfemo Kids&Teens VINTAGE MODE Study Desk','Alfemo Kids&Teens VINTAGE MODE Study Desk',430.08,33,9),(28,'Alfemo BROOKLYN Dining Table','A unique inspiration',338.88,16,2),(29,'Alfemo SIENA Dining Table','Charm of the white color',372.48,26,2);
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
) ENGINE=InnoDB AUTO_INCREMENT=110 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_attributes`
--

LOCK TABLES `product_attributes` WRITE;
/*!40000 ALTER TABLE `product_attributes` DISABLE KEYS */;
INSERT INTO `product_attributes` VALUES (15,5,3,2,1),(16,5,5,2,3),(17,5,11,2,5),(18,5,16,2,6),(19,5,17,2,7),(20,6,1,3,1),(21,6,5,3,3),(22,6,9,3,4),(23,7,1,6,1),(24,7,5,6,3),(33,10,3,4,1),(34,10,5,4,3),(35,10,13,4,5),(36,10,15,4,6),(37,10,18,4,7),(41,12,1,1,1),(42,12,6,1,2),(43,12,4,1,3),(55,13,19,1,1),(56,13,6,1,2),(57,13,5,1,3),(58,14,19,3,1),(59,14,5,3,3),(60,14,28,3,4),(64,15,21,3,1),(65,15,5,3,3),(66,15,28,3,4),(67,16,21,5,1),(68,16,5,5,3),(69,16,11,5,5),(70,16,16,5,6),(71,16,17,5,7),(72,17,21,7,1),(73,17,5,7,3),(74,17,16,7,6),(75,17,17,7,7),(76,18,2,1,1),(77,18,7,1,2),(78,18,5,1,3),(79,19,19,4,1),(80,19,5,4,3),(81,19,11,4,5),(82,19,16,4,6),(83,19,17,4,7),(84,20,3,8,1),(85,20,25,8,3),(86,21,2,8,1),(87,21,25,8,3),(88,22,29,8,1),(89,22,25,8,3),(90,23,2,8,1),(91,23,25,8,3),(92,24,30,8,1),(93,24,25,8,3),(94,25,19,9,1),(95,25,5,9,3),(96,25,12,9,5),(97,25,18,9,7),(98,26,21,9,1),(99,26,4,9,3),(100,26,12,9,5),(101,26,17,9,7),(102,27,21,9,1),(103,27,4,9,3),(104,27,12,9,5),(105,27,17,9,7),(106,28,21,2,1),(107,28,4,2,3),(108,29,23,2,1),(109,29,5,2,3);
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
INSERT INTO `province` VALUES (1,'İstanbul'),(2,'İzmir'),(3,'Ankara');
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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sell`
--

LOCK TABLES `sell` WRITE;
/*!40000 ALTER TABLE `sell` DISABLE KEYS */;
INSERT INTO `sell` VALUES (3,3,7,20.00,'2019-05-15 17:58:55',2),(4,4,7,3.00,'2019-05-12 19:36:11',5),(5,4,7,1.00,'2019-05-12 19:36:16',1),(6,12,23,900.00,'2019-05-14 21:51:05',1),(7,9,27,410.00,'2019-05-11 21:51:53',1),(8,6,18,4500.00,'2019-05-09 21:59:03',3),(9,2,16,1.00,'2019-05-19 02:16:13',1);
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
INSERT INTO `supplier` VALUES (1,'Ikea','05474458633','tattoine',2,18),(2,'Bellona','05476698333','maslak',1,1),(3,'Yatas','08527538426','new york',2,16),(4,'Tekzen','03574156985','karayipler',3,21),(5,'Istikbal','35786542188','karayipler',2,11),(6,'Moda','35687123897','ankara',3,30),(7,'Englishhome','03568876524','ankara',3,28),(8,'Koctas','07536988544','ankara',3,25),(9,'Bambi','04566683274','istinye',1,6),(10,'Visko','05746682569','washington',2,13),(11,'Alfemo','0535445687','Yıldız Sokak',1,8);
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

-- Dump completed on 2019-05-23  7:19:26
