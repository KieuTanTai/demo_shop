-- Identity system seed data
-- Target schema:
--   role
--   permission
--   role_permission
--
-- Admin is a system-level super role and therefore does NOT receive
-- explicit rows in role_permission.
USE `ms_identity_test`;
START TRANSACTION;

-- ============================================================
-- ROLES
-- ============================================================

INSERT INTO `role`
    (`role_code`, `role_name`, `role_description`, `role_is_active`)
VALUES ('CUSTOMER',
        'Customer',
        'Customer role for browsing products, managing cart items, and making purchases.',
        TRUE),

       ('EMPLOYEE',
        'Employee',
        'Employee role for selling existing products and reading role information and own permissions.',
        TRUE),

       ('ASSISTANT',
        'Assistant',
        'Assistant role with all Employee capabilities plus statistics access.',
        TRUE),

       ('MANAGER',
        'Manager',
        'Manager role for product, customer, order, role and permission management, plus statistics access.',
        TRUE),

       ('ADMIN',
        'Admin',
        'System administrator with full administrative permissions. Customer purchase and employee selling capabilities are not assigned as explicit permissions.',
        TRUE);

-- ============================================================
-- PERMISSIONS
-- ============================================================

INSERT INTO `permission`
(`permission_code`, `permission_name`, `permission_description`, `permission_is_active`)
VALUES
    -- Product
    ('PRODUCT_READ',
     'Product Read',
     'Read product information.',
     TRUE),

    ('PRODUCT_CREATE',
     'Product Create',
     'Create products.',
     TRUE),

    ('PRODUCT_UPDATE',
     'Product Update',
     'Update product information.',
     TRUE),

    ('PRODUCT_DELETE',
     'Product Delete',
     'Delete products.',
     TRUE),

    ('PRODUCT_SELL',
     'Product Sell',
     'Sell an existing product through employee-operated sales flows.',
     TRUE),

    -- Cart
    ('CART_READ',
     'Cart Read',
     'Read the current shopping cart.',
     TRUE),

    ('CART_ADD_ITEM',
     'Cart Add Item',
     'Add a product to the shopping cart.',
     TRUE),

    ('CART_UPDATE_ITEM',
     'Cart Update Item',
     'Update an item already present in the shopping cart.',
     TRUE),

    ('CART_REMOVE_ITEM',
     'Cart Remove Item',
     'Remove an item from the shopping cart.',
     TRUE),

    -- Purchase
    ('PURCHASE_CREATE',
     'Purchase Create',
     'Initiate a customer purchase. The system creates the corresponding order.',
     TRUE),

    -- Order administration
    ('ORDER_READ',
     'Order Read',
     'Read order information for operational or administrative purposes.',
     TRUE),

    ('ORDER_CREATE',
     'Order Create',
     'Create an order through administrative or operational order-management flows.',
     TRUE),

    ('ORDER_UPDATE',
     'Order Update',
     'Update an existing order.',
     TRUE),

    ('ORDER_DELETE',
     'Order Delete',
     'Delete an order.',
     TRUE),

    -- Customer management
    ('CUSTOMER_READ',
     'Customer Read',
     'Read customer information.',
     TRUE),

    ('CUSTOMER_CREATE',
     'Customer Create',
     'Create a customer account through administrative flows.',
     TRUE),

    ('CUSTOMER_UPDATE',
     'Customer Update',
     'Update customer information.',
     TRUE),

    ('CUSTOMER_DELETE',
     'Customer Delete',
     'Delete a customer account.',
     TRUE),

    -- Role management
    ('ROLE_READ',
     'Role Read',
     'Read role information.',
     TRUE),

    ('ROLE_CREATE',
     'Role Create',
     'Create roles.',
     TRUE),

    ('ROLE_UPDATE',
     'Role Update',
     'Update roles and role assignments within the caller allowed scope.',
     TRUE),

    ('ROLE_DELETE',
     'Role Delete',
     'Delete roles.',
     TRUE),

    -- Permission management
    ('PERMISSION_READ',
     'Permission Read',
     'Read permission information. Application-level authorization may restrict visibility to the caller own permissions.',
     TRUE),

    ('PERMISSION_CREATE',
     'Permission Create',
     'Create permissions.',
     TRUE),

    ('PERMISSION_UPDATE',
     'Permission Update',
     'Update permissions or permission assignments within the caller allowed scope.',
     TRUE),

    ('PERMISSION_DELETE',
     'Permission Delete',
     'Delete permissions.',
     TRUE),

    -- Statistics
    ('STATISTICS_READ',
     'Statistics Read',
     'Read system or business statistics.',
     TRUE);

-- ============================================================
-- ROLE -> PERMISSION
-- ============================================================

-- CUSTOMER
INSERT INTO `role_permission` (`role_id`, `permission_id`)
SELECT r.`role_id`, p.`permission_id`
FROM `role` r
         CROSS JOIN `permission` p
WHERE r.`role_code` = 'CUSTOMER'
  AND p.`permission_code` IN (
                              'PRODUCT_READ',
                              'CART_READ',
                              'CART_ADD_ITEM',
                              'CART_UPDATE_ITEM',
                              'CART_REMOVE_ITEM',
                              'PURCHASE_CREATE'
    );

-- EMPLOYEE
INSERT INTO `role_permission` (`role_id`, `permission_id`)
SELECT r.`role_id`, p.`permission_id`
FROM `role` r
         CROSS JOIN `permission` p
WHERE r.`role_code` = 'EMPLOYEE'
  AND p.`permission_code` IN (
                              'PRODUCT_READ',
                              'PRODUCT_SELL',
                              'ROLE_READ',
                              'PERMISSION_READ'
    );

-- ASSISTANT
INSERT INTO `role_permission` (`role_id`, `permission_id`)
SELECT r.`role_id`, p.`permission_id`
FROM `role` r
         CROSS JOIN `permission` p
WHERE r.`role_code` = 'ASSISTANT'
  AND p.`permission_code` IN (
                              'PRODUCT_READ',
                              'PRODUCT_SELL',
                              'ROLE_READ',
                              'PERMISSION_READ',
                              'STATISTICS_READ'
    );

-- MANAGER
INSERT INTO `role_permission` (`role_id`, `permission_id`)
SELECT r.`role_id`, p.`permission_id`
FROM `role` r
         CROSS JOIN `permission` p
WHERE r.`role_code` = 'MANAGER'
  AND p.`permission_code` IN (
    -- Product management
                              'PRODUCT_READ',
                              'PRODUCT_CREATE',
                              'PRODUCT_UPDATE',
                              'PRODUCT_DELETE',

    -- Customer management
                              'CUSTOMER_READ',
                              'CUSTOMER_CREATE',
                              'CUSTOMER_UPDATE',
                              'CUSTOMER_DELETE',

    -- Manual / administrative order management
                              'ORDER_READ',
                              'ORDER_CREATE',
                              'ORDER_UPDATE',
                              'ORDER_DELETE',

    -- Role / permission management
                              'ROLE_READ',
                              'ROLE_UPDATE',
                              'PERMISSION_READ',
                              'PERMISSION_UPDATE',

    -- Statistics
                              'STATISTICS_READ'
    );

-- ADMIN
-- Intentionally no rows.
-- ADMIN is treated as a system-level super role by authorization logic.
-- In particular, ADMIN does not receive:
--   PURCHASE_CREATE
--   PRODUCT_SELL

COMMIT;

select *
from role;
select *
from permission;
select *
from role_permission;
