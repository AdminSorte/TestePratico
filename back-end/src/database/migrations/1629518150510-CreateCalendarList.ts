import { MigrationInterface, QueryRunner, Table } from "typeorm";

export class CreateCalendarList1629518150510 implements MigrationInterface {

    public async up(queryRunner: QueryRunner): Promise<void> {

        await queryRunner.createTable(

            new Table({
                name: 'calendar_list',
                columns: [
                    {
                        name: 'id',
                        type: 'uuid',
                        isPrimary: true
                    },
                    {
                        name: 'date',
                        type: 'varchar'
                    },
                    {
                        name: 'description_short',
                        type: 'varchar'
                    },
                    {
                        name: 'description',
                        type: 'varchar'
                    },
                    {
                        name: "created_at",
                        type: "timestamp",
                        default: "now()"
                    },
                    {
                        name: "updated_at",
                        type: "timestamp",
                        default: "now()"
                    },
                ]
            })

        )

    }

    public async down(queryRunner: QueryRunner): Promise<void> {

        await queryRunner.dropTable('calendar_list');

    }

}
