const sum = require('./sum');


test("add 1 + 2 to be eqquals 3", () => {
    expect(sum(1, 2)).toBe(3);
});