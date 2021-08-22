import { Entity, PrimaryColumn, Column, CreateDateColumn, UpdateDateColumn } from "typeorm";

import { v4 as uuidV4 } from 'uuid';

@Entity('calendar_list')

class CalendarList {

    @PrimaryColumn()
    readonly id: string;

    @Column()
    date: string;
    
    @Column()
    description_short: string;

    @Column()
    description: string;

    @CreateDateColumn()
    created_at: Date;

    @UpdateDateColumn()
    updated_at: Date;

    constructor() {

        if(!this.id) {

            this.id = uuidV4();

        }

    }

}

export { CalendarList };