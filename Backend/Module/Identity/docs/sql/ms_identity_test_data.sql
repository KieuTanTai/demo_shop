/*M!999999\- enable the sandbox mode */ 
-- MariaDB dump 10.20-12.3.3-MariaDB, for Linux (x86_64)
--
-- Host: localhost    Database: ms_identity_test
-- ------------------------------------------------------
-- Server version	12.3.3-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*M!100616 SET @OLD_NOTE_VERBOSITY=@@NOTE_VERBOSITY, NOTE_VERBOSITY=0 */;

--
-- Dumping data for table `account`
--

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
INSERT INTO `account` VALUES
('01a051c7-348f-7dc8-9f4a-d9efcd9171e3','admin@test.local','AQAAAAIAAYagAAAAEAz/BA0pgAKp5ahy/1tMhmt7khlVrYvo0GCulvi2ym3rWacE0ZScX+gDD3gKqydn2w==','2026-08-30 08:26:44','2026-08-30 08:26:44',1,'0843220322'),
('01a051c7-348f-7f88-9c23-9c1c8b0ea021','manager@test.local','AQAAAAIAAYagAAAAEDf0wt9ryzFhqxZft80HaGNb7Yv/OVKXUuvkHovBxNpTw7qalKTZF4/ti9HEIyjZbQ==','2026-08-30 08:26:44','2026-08-30 08:26:44',1,'0843220324'),
('01a051c7-3490-701c-ac2a-28bc50582f30','assistant@test.local','AQAAAAIAAYagAAAAEDYaPzmu2h8W2sZ33QQ/OYuprReCo7BPM9siibdL09gYtpRw50XHj+g1PguBu3xXTg==','2026-08-30 08:26:44','2026-08-30 08:26:44',1,'0843220326'),
('01a051c7-3490-702c-944f-b6b57ab43f9f','employee01@test.local','AQAAAAIAAYagAAAAEKeyfBQB/OC+VsbbRDciNisAhoV/oUY+Teh1C2Cpfpr9ll6thnEcBSdUGkxszn9kSg==','2026-08-30 08:26:44','2026-08-30 08:26:44',1,'0843210324'),
('01a051c7-3490-7034-b170-58e933015301','employee02@test.local','AQAAAAIAAYagAAAAENsCZhsu4W1yBiIatCqeIAcaREMjRXaEj7nNQz9RAsapj/s7Oz+QSpr3YmsKXpj0bQ==','2026-08-30 08:26:44','2026-08-30 08:26:44',1,'0843220024'),
('01a051c7-3490-7040-84fe-d385f1e01893','customer01@test.local','AQAAAAIAAYagAAAAEH3TW6BxPBFjDYVGH4ZE1jkJa2eFiPUrAukku6cYysQwxDh/1xuzYHJ7qnSMfvWxqg==','2026-08-30 08:26:44','2026-08-30 08:26:44',1,'0841210324'),
('01a051c7-3490-7048-a9eb-cea8b71457d4','customer02@test.local','AQAAAAIAAYagAAAAELGlvVRO682XRAzbtiKtK0FWKRV/LKrKqoWjoOsUO7VWh7uJt4gZFba6GJVmdtudLA==','2026-08-30 08:26:44','2026-08-30 08:26:44',1,'0843120314');
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;

--
-- Dumping data for table `account_additional_permission`
--

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `account_additional_permission` WRITE;
/*!40000 ALTER TABLE `account_additional_permission` DISABLE KEYS */;
/*!40000 ALTER TABLE `account_additional_permission` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;

--
-- Dumping data for table `account_role`
--

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `account_role` WRITE;
/*!40000 ALTER TABLE `account_role` DISABLE KEYS */;
INSERT INTO `account_role` VALUES
('01a051c7-348f-7dc8-9f4a-d9efcd9171e3','01a051af-9437-76c8-8f78-a81d8adc39a9','2026-08-30 08:26:44'),
('01a051c7-348f-7f88-9c23-9c1c8b0ea021','01a051af-9437-76b4-b8c9-e8c6df7afed1','2026-08-30 08:26:44'),
('01a051c7-3490-701c-ac2a-28bc50582f30','01a051af-9437-76a0-9c06-c29078c39700','2026-08-30 08:26:44'),
('01a051c7-3490-702c-944f-b6b57ab43f9f','01a051af-9437-762c-aed6-cd9b17c2087d','2026-08-30 08:26:44'),
('01a051c7-3490-7034-b170-58e933015301','01a051af-9437-762c-aed6-cd9b17c2087d','2026-08-30 08:26:44'),
('01a051c7-3490-7040-84fe-d385f1e01893','01a051af-9435-7adc-8e9c-da23a19b15c2','2026-08-30 08:26:44'),
('01a051c7-3490-7048-a9eb-cea8b71457d4','01a051af-9435-7adc-8e9c-da23a19b15c2','2026-08-30 08:26:44');
/*!40000 ALTER TABLE `account_role` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;

--
-- Dumping data for table `permission`
--

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `permission` WRITE;
/*!40000 ALTER TABLE `permission` DISABLE KEYS */;
INSERT INTO `permission` VALUES
('01a051af-946c-72a4-a6c6-551fe6acd424','PRODUCT_READ','Product Read','Read product information.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-744c-bb35-c5aa3945bc13','PRODUCT_CREATE','Product Create','Create products.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-748c-9985-74c4c4d5a444','PRODUCT_UPDATE','Product Update','Update product information.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-74a4-a02a-f7f91726a69f','PRODUCT_DELETE','Product Delete','Delete products.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-74bc-9eee-46881768de9c','PRODUCT_SELL','Product Sell','Sell an existing product through employee-operated sales flows.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-74f0-8728-9e77d7bb7299','CART_READ','Cart Read','Read the current shopping cart.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-754c-a2fa-77bc65adf59f','CART_ADD_ITEM','Cart Add Item','Add a product to the shopping cart.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-7570-893e-4a3c427db2dc','CART_UPDATE_ITEM','Cart Update Item','Update an item already present in the shopping cart.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-7588-991a-59de09e2c5e8','CART_REMOVE_ITEM','Cart Remove Item','Remove an item from the shopping cart.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-759c-b958-afcad2edf0b8','PURCHASE_CREATE','Purchase Create','Initiate a customer purchase. The system creates the corresponding order.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-75b4-9beb-0ac735589d06','ORDER_READ','Order Read','Read order information for operational or administrative purposes.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-75cc-8d4e-62ca9f5dcf9e','ORDER_CREATE','Order Create','Create an order through administrative or operational order-management flows.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-75e0-bde1-a99e6e4b3e46','ORDER_UPDATE','Order Update','Update an existing order.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-75f4-9a8a-20638b0d6f7e','ORDER_DELETE','Order Delete','Delete an order.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-760c-b3ef-9961ca5be7bc','CUSTOMER_READ','Customer Read','Read customer information.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-761c-bbd3-06bb6f75c5cf','CUSTOMER_CREATE','Customer Create','Create a customer account through administrative flows.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-7640-b498-f393d1529573','CUSTOMER_UPDATE','Customer Update','Update customer information.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-7658-b0f8-0f2cf87e974c','CUSTOMER_DELETE','Customer Delete','Delete a customer account.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-766c-849a-a49240501298','ROLE_READ','Role Read','Read role information.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-7680-9915-5f17bed0a0a0','ROLE_CREATE','Role Create','Create roles.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-7694-bafb-823c7edea287','ROLE_UPDATE','Role Update','Update roles and role assignments within the caller allowed scope.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-76ac-af02-78ba8e7092f0','ROLE_DELETE','Role Delete','Delete roles.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-76c4-a944-79611fc91a0e','PERMISSION_READ','Permission Read','Read permission information. Application-level authorization may restrict visibility to the caller own permissions.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-76d8-897f-cd85fd638811','PERMISSION_CREATE','Permission Create','Create permissions.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-76f0-a865-99bfa7c14279','PERMISSION_UPDATE','Permission Update','Update permissions or permission assignments within the caller allowed scope.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-7704-893d-14361b146ae0','PERMISSION_DELETE','Permission Delete','Delete permissions.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-946c-7718-9196-56ebc84f553c','STATISTICS_READ','Statistics Read','Read system or business statistics.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56');
/*!40000 ALTER TABLE `permission` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;

--
-- Dumping data for table `role`
--

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES
('01a051af-9435-7adc-8e9c-da23a19b15c2','CUSTOMER','Customer','Customer role for browsing products, managing cart items, and making purchases.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-9437-762c-aed6-cd9b17c2087d','EMPLOYEE','Employee','Employee role for selling existing products and reading role information and own permissions.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-9437-76a0-9c06-c29078c39700','ASSISTANT','Assistant','Assistant role with all Employee capabilities plus statistics access.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','MANAGER','Manager','Manager role for product, customer, order, role and permission management, plus statistics access.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56'),
('01a051af-9437-76c8-8f78-a81d8adc39a9','ADMIN','Admin','System administrator with full administrative permissions. Customer purchase and employee selling capabilities are not assigned as explicit permissions.',1,'2026-08-30 08:00:56','2026-08-30 08:00:56');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;

--
-- Dumping data for table `role_permission`
--

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `role_permission` WRITE;
/*!40000 ALTER TABLE `role_permission` DISABLE KEYS */;
INSERT INTO `role_permission` VALUES
('01a051af-9435-7adc-8e9c-da23a19b15c2','01a051af-946c-72a4-a6c6-551fe6acd424','2026-08-30 08:00:56'),
('01a051af-9435-7adc-8e9c-da23a19b15c2','01a051af-946c-74f0-8728-9e77d7bb7299','2026-08-30 08:00:56'),
('01a051af-9435-7adc-8e9c-da23a19b15c2','01a051af-946c-754c-a2fa-77bc65adf59f','2026-08-30 08:00:56'),
('01a051af-9435-7adc-8e9c-da23a19b15c2','01a051af-946c-7570-893e-4a3c427db2dc','2026-08-30 08:00:56'),
('01a051af-9435-7adc-8e9c-da23a19b15c2','01a051af-946c-7588-991a-59de09e2c5e8','2026-08-30 08:00:56'),
('01a051af-9435-7adc-8e9c-da23a19b15c2','01a051af-946c-759c-b958-afcad2edf0b8','2026-08-30 08:00:56'),
('01a051af-9437-762c-aed6-cd9b17c2087d','01a051af-946c-72a4-a6c6-551fe6acd424','2026-08-30 08:00:56'),
('01a051af-9437-762c-aed6-cd9b17c2087d','01a051af-946c-74bc-9eee-46881768de9c','2026-08-30 08:00:56'),
('01a051af-9437-762c-aed6-cd9b17c2087d','01a051af-946c-766c-849a-a49240501298','2026-08-30 08:00:56'),
('01a051af-9437-762c-aed6-cd9b17c2087d','01a051af-946c-76c4-a944-79611fc91a0e','2026-08-30 08:00:56'),
('01a051af-9437-76a0-9c06-c29078c39700','01a051af-946c-72a4-a6c6-551fe6acd424','2026-08-30 08:00:56'),
('01a051af-9437-76a0-9c06-c29078c39700','01a051af-946c-74bc-9eee-46881768de9c','2026-08-30 08:00:56'),
('01a051af-9437-76a0-9c06-c29078c39700','01a051af-946c-766c-849a-a49240501298','2026-08-30 08:00:56'),
('01a051af-9437-76a0-9c06-c29078c39700','01a051af-946c-76c4-a944-79611fc91a0e','2026-08-30 08:00:56'),
('01a051af-9437-76a0-9c06-c29078c39700','01a051af-946c-7718-9196-56ebc84f553c','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-72a4-a6c6-551fe6acd424','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-744c-bb35-c5aa3945bc13','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-748c-9985-74c4c4d5a444','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-74a4-a02a-f7f91726a69f','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-75b4-9beb-0ac735589d06','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-75cc-8d4e-62ca9f5dcf9e','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-75e0-bde1-a99e6e4b3e46','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-75f4-9a8a-20638b0d6f7e','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-760c-b3ef-9961ca5be7bc','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-761c-bbd3-06bb6f75c5cf','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-7640-b498-f393d1529573','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-7658-b0f8-0f2cf87e974c','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-766c-849a-a49240501298','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-7694-bafb-823c7edea287','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-76c4-a944-79611fc91a0e','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-76f0-a865-99bfa7c14279','2026-08-30 08:00:56'),
('01a051af-9437-76b4-b8c9-e8c6df7afed1','01a051af-946c-7718-9196-56ebc84f553c','2026-08-30 08:00:56');
/*!40000 ALTER TABLE `role_permission` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*M!100616 SET NOTE_VERBOSITY=@OLD_NOTE_VERBOSITY */;

-- Dump completed on 2026-08-30 17:49:40
