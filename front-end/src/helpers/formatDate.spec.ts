import { formatDate } from "./formatDate";

describe('function formatDate', () => {

    it('should presents correct formatting', () => {

        const dateFake = "2021-08-22";

        expect(formatDate(dateFake)).toEqual('22/08/2021');

    })

})