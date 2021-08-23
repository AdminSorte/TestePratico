import { render, screen } from "@testing-library/react";

import Info from "./[id]";

describe("Page Info", () => {

    it("should renders correctly", () => {

        const infoFake = {
            id: "fake-id",
            date: "2021-08-22",
            description: "fake description",
            description_short: "fake description_short"
        }

        render(<Info info={infoFake} />);

        expect(screen.getByText("fake description")).toBeInTheDocument();

    })

})