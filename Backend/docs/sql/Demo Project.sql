CREATE TABLE `Account` (
  `account_id` uuid PRIMARY KEY,
  `account_email` varchar(255) UNIQUE NOT NULL,
  `account_password` varchar(50) NOT NULL,
  `account_login_status` boolean DEFAULT true,
  `account_created_at` timestamp,
  `account_updated_at` timestamp
);

CREATE TABLE `Role` (
  `role_id` uuid PRIMARY KEY,
  `role_name` varchar(100) UNIQUE NOT NULL,
  `role_description` tinytext,
  `role_active` boolean DEFAULT true,
  `role_created_at` timestamp,
  `role_updated_at` timestamp
);

CREATE TABLE `Permission` (
  `permission_id` uuid PRIMARY KEY,
  `permission_name` varchar(150) UNIQUE NOT NULL,
  `permission_description` tinytext,
  `permission_created_at` timestamp
);

CREATE TABLE `Account_Role` (
  `account_id` uuid,
  `role_id` uuid,
  `assigned_at` timestamp,
  PRIMARY KEY (`account_id`, `role_id`)
);

CREATE TABLE `Role_Permission` (
  `role_id` uuid,
  `permission_id` uuid,
  `assigned_at` timestamp,
  PRIMARY KEY (`role_id`, `permission_id`)
);

CREATE TABLE `Account_Permission` (
  `account_id` uuid,
  `permission_id` uuid,
  `assigned_at` timestamp,
  PRIMARY KEY (`account_id`, `permission_id`)
);

ALTER TABLE `Account_Role` ADD FOREIGN KEY (`account_id`) REFERENCES `Account` (`account_id`);

ALTER TABLE `Account_Role` ADD FOREIGN KEY (`role_id`) REFERENCES `Role` (`role_id`);

ALTER TABLE `Role_Permission` ADD FOREIGN KEY (`role_id`) REFERENCES `Role` (`role_id`);

ALTER TABLE `Role_Permission` ADD FOREIGN KEY (`permission_id`) REFERENCES `Permission` (`permission_id`);

ALTER TABLE `Account_Permission` ADD FOREIGN KEY (`account_id`) REFERENCES `Account` (`account_id`);

ALTER TABLE `Account_Permission` ADD FOREIGN KEY (`permission_id`) REFERENCES `Permission` (`permission_id`);
