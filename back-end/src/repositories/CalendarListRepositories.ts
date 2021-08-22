import { Repository, EntityRepository } from "typeorm";

import { CalendarList } from './../entities/CalendarList';

@EntityRepository(CalendarList)
class CalendarListRepositories extends Repository<CalendarList> {};

export { CalendarListRepositories };
