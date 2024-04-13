SELECT
    prod.name as "Продукт",
    cat.name as "Категория"
FROM product prod
         LEFT JOIN product_category pc ON prod.id = pc.product_id
         LEFT JOIN category cat ON cat.id = pc.category_id;