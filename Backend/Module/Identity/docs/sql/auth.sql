CREATE TABLE `account` (
  `account_id` uuid PRIMARY KEY DEFAULT (uuid_v7()),
  `account_email` varchar(255) UNIQUE NOT NULL,
  `account_password` varchar(50) NOT NULL,
  `account_login_status` boolean DEFAULT false,
  `account_created_at` timestamp DEFAULT (now()),
  `account_updated_at` timestamp DEFAULT (now())
);

CREATE TABLE `role` (
  `role_id` uuid PRIMARY KEY DEFAULT (uuid_v7()),
  `role_name` varchar(100) UNIQUE NOT NULL,
  `role_description` tinytext NOT NULL DEFAULT '',
  `role_active` boolean DEFAULT true,
  `role_created_at` timestamp DEFAULT (now()),
  `role_updated_at` timestamp DEFAULT (now())
);

CREATE TABLE `permission` (
  `permission_id` uuid PRIMARY KEY DEFAULT (uuid_v7()),
  `permission_name` varchar(150) UNIQUE NOT NULL,
  `permission_description` tinytext NOT NULL DEFAULT '',
  `permission_active` boolean DEFAULT true,
  `permission_created_at` timestamp DEFAULT (now()),
  `permission_updated_at` timestamp DEFAULT (now())
);

CREATE TABLE `account_role` (
  `account_id` uuid,
  `role_id` uuid,
  `assigned_at` timestamp DEFAULT (now()),
  PRIMARY KEY (`account_id`, `role_id`)
);

CREATE TABLE `role_permission` (
  `role_id` uuid,
  `permission_id` uuid,
  `assigned_at` timestamp DEFAULT (now()),
  PRIMARY KEY (`role_id`, `permission_id`)
);

CREATE TABLE `account_permission` (
  `account_id` uuid,
  `permission_id` uuid,
  `assigned_at` timestamp DEFAULT (now()),
  PRIMARY KEY (`account_id`, `permission_id`)
);

ALTER TABLE `account_role` ADD FOREIGN KEY (`account_id`) REFERENCES `account` (`account_id`);

ALTER TABLE `account_role` ADD FOREIGN KEY (`role_id`) REFERENCES `role` (`role_id`);

ALTER TABLE `role_permission` ADD FOREIGN KEY (`role_id`) REFERENCES `role` (`role_id`);

ALTER TABLE `role_permission` ADD FOREIGN KEY (`permission_id`) REFERENCES `permission` (`permission_id`);

ALTER TABLE `account_permission` ADD FOREIGN KEY (`account_id`) REFERENCES `account` (`account_id`);

ALTER TABLE `account_permission` ADD FOREIGN KEY (`permission_id`) REFERENCES `permission` (`permission_id`);

ALTER TABLE `account`
    MODIFY COLUMN `account_password`
        VARCHAR(255)
        NOT NULL;

ALTER TABLE `account`
    DROP COLUMN `account_login_status`,
    ADD COLUMN `account_is_active` BOOLEAN NOT NULL DEFAULT TRUE;

ALTER TABLE `account`
    MODIFY COLUMN `account_phone` varchar(10);

ALTER TABLE `role`
    MODIFY COLUMN `role_description` VARCHAR(300) NOT NULL DEFAULT '';

ALTER TABLE `permission`
    MODIFY COLUMN `permission_description` VARCHAR(300) NOT NULL DEFAULT '';

SHOW COLUMNS FROM account;
SHOW COLUMNS FROM role;
SHOW COLUMNS FROM permission;

SHOW VARIABLES LIKE 'character_set_server';
SHOW VARIABLES LIKE 'collation_server';