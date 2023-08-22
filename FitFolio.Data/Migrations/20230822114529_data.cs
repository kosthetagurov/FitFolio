using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"insert into ""ExerciseCategories"" (""Id"", ""Name"", ""Logo"") values ('1afefa79-49c6-449c-a72f-d9e421218036', 'Грудные мышцы', '');
                        insert into ""Exercises"" (""Id"", ""Name"", ""Description"", ""Logo"", ""ExerciseCategoryId"") values (gen_random_uuid(), 'Жим штанги лежа', '', '' ,'1afefa79-49c6-449c-a72f-d9e421218036'),
                        (gen_random_uuid(), 'Жим гантелей лежа', '', '' ,'1afefa79-49c6-449c-a72f-d9e421218036'),
                        (gen_random_uuid(), 'Жим штанги на наклонной скамье', '', '' ,'1afefa79-49c6-449c-a72f-d9e421218036'),
                        (gen_random_uuid(), 'Разведение гантелей на скамье', '', '' ,'1afefa79-49c6-449c-a72f-d9e421218036'),
                        (gen_random_uuid(), 'Жим гантелей на наклонной скамье', '', '' ,'1afefa79-49c6-449c-a72f-d9e421218036'),
                        (gen_random_uuid(), 'Кроссовер внизу', '', '' ,'1afefa79-49c6-449c-a72f-d9e421218036');

                        insert into ""ExerciseCategories"" (""Id"", ""Name"", ""Logo"") values ('97ca7b99-2fe1-4707-b55b-9fd48c5be3f6', 'Спина', '');
                        insert into ""Exercises"" (""Id"", ""Name"", ""Description"", ""Logo"", ""ExerciseCategoryId"") values (gen_random_uuid(), 'Тяга вертикального блока', '', '', '97ca7b99-2fe1-4707-b55b-9fd48c5be3f6'),
                        (gen_random_uuid(), 'Тяга горизонтального блока', '', '', '97ca7b99-2fe1-4707-b55b-9fd48c5be3f6'),
                        (gen_random_uuid(), 'Мертвая тяга', '', '', '97ca7b99-2fe1-4707-b55b-9fd48c5be3f6'),
                        (gen_random_uuid(), 'Гиперэкстензия спины', '', '', '97ca7b99-2fe1-4707-b55b-9fd48c5be3f6');

                        insert into ""ExerciseCategories"" (""Id"", ""Name"", ""Logo"") values ('5c2520ce-eb06-4ef4-8334-1e0440e12bb8', 'Плечи', '');
                        insert into ""Exercises"" (""Id"", ""Name"", ""Description"", ""Logo"", ""ExerciseCategoryId"") values (gen_random_uuid(), 'Армейский жим стоя', '', '', '5c2520ce-eb06-4ef4-8334-1e0440e12bb8'),
                        (gen_random_uuid(), 'Жим штанги перед собой', '', '', '5c2520ce-eb06-4ef4-8334-1e0440e12bb8'),
                        (gen_random_uuid(), 'Подъем гантелей в стороны', '', '', '5c2520ce-eb06-4ef4-8334-1e0440e12bb8'),
                        (gen_random_uuid(), 'Подъем гантелей перед собой', '', '', '5c2520ce-eb06-4ef4-8334-1e0440e12bb8'),
                        (gen_random_uuid(), 'Тяга вертикального блока к плечу', '', '', '5c2520ce-eb06-4ef4-8334-1e0440e12bb8');

                        insert into ""ExerciseCategories"" (""Id"", ""Name"", ""Logo"") values ('1ff49ddc-ce6b-4244-9557-1750b79a85fe', 'Ноги', '');
                        insert into ""Exercises"" (""Id"", ""Name"", ""Description"", ""Logo"", ""ExerciseCategoryId"") values (gen_random_uuid(), 'Приседания со штангой на плечах', '', '', '1ff49ddc-ce6b-4244-9557-1750b79a85fe'),
                        (gen_random_uuid(), 'Гак-приседания', '', '', '1ff49ddc-ce6b-4244-9557-1750b79a85fe'),
                        (gen_random_uuid(), 'Жим ногами в тренажере', '', '', '1ff49ddc-ce6b-4244-9557-1750b79a85fe'),
                        (gen_random_uuid(), 'Разгибание ног в тренажере', '', '', '1ff49ddc-ce6b-4244-9557-1750b79a85fe'),
                        (gen_random_uuid(), 'Сгибание ног в тренажере на бицепс бедра', '', '', '1ff49ddc-ce6b-4244-9557-1750b79a85fe');

                        insert into ""ExerciseCategories"" (""Id"", ""Name"", ""Logo"") values ('dd94cdee-76f9-4530-ae63-bc394d971054', 'Руки', '');
                        insert into ""Exercises"" (""Id"", ""Name"", ""Description"", ""Logo"", ""ExerciseCategoryId"") values (gen_random_uuid(), 'Сгибание рук со штангой (бицепс)', '', '', 'dd94cdee-76f9-4530-ae63-bc394d971054'),
                        (gen_random_uuid(), 'Сгибание рук с гантелями (бицепс)', '', '', 'dd94cdee-76f9-4530-ae63-bc394d971054'),
                        (gen_random_uuid(), 'Разгибание рук на блоке (трицепс)', '', '', 'dd94cdee-76f9-4530-ae63-bc394d971054'),
                        (gen_random_uuid(), 'Отжимания на брусьях (трицепс)', '', '', 'dd94cdee-76f9-4530-ae63-bc394d971054'),
                        (gen_random_uuid(), 'Французский жим со штангой (трицепс)', '', '', 'dd94cdee-76f9-4530-ae63-bc394d971054');

                        insert into ""ExerciseCategories"" (""Id"", ""Name"", ""Logo"") values ('fdb132d5-2393-4080-b651-258f53668cdf', 'Пресс', '');
                        insert into ""Exercises"" (""Id"", ""Name"", ""Description"", ""Logo"", ""ExerciseCategoryId"") values (gen_random_uuid(), 'Подъем ног в висе на перекладине', '', '','fdb132d5-2393-4080-b651-258f53668cdf'),
                        (gen_random_uuid(), 'Скручивания на скамье', '', '','fdb132d5-2393-4080-b651-258f53668cdf'),
                        (gen_random_uuid(), 'Планка', '', '','fdb132d5-2393-4080-b651-258f53668cdf');";

            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Exercises");
            migrationBuilder.Sql("DELETE FROM ExerciseCategories");
        }
    }
}
