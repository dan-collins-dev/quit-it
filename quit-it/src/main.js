"use strict";

const logModal = document.getElementById("log-cigarette");
const addBtn = document.getElementById("add-btn");
const dateInput = document.getElementById("date-input");

function setCalendarLimit() {
    const today = new Date();
    const formattedToday = today.toDateString().slice(0, 10);

    document.getElementById(dateInput)[0].min = formattedToday;
}

const smokerLogs = [
    {
        id: 1,
        date: new Date(2026, 2, 1).getTime(), // March 1, 2026
        numOfCigarettes: 15,
    },
    {
        id: 2,
        date: new Date(2026, 2, 2).getTime(), // March 2, 2026
        numOfCigarettes: 12,
    },
    {
        id: 3,
        date: new Date(2026, 2, 3).getTime(), // March 3, 2026
        numOfCigarettes: 18,
    },
    {
        id: 4,
        date: new Date(2026, 2, 4).getTime(), // March 4, 2026
        numOfCigarettes: 10,
    },
    {
        id: 5,
        date: new Date(2026, 2, 5).getTime(), // March 5, 2026
        numOfCigarettes: 23,
    },
    {
        id: 6,
        date: new Date(2026, 2, 5).getTime(), // March 5, 2026
        numOfCigarettes: 2,
    },
];

async function getData() {
    try {
        const res = await fetch("http://localhost:7070");
        const data = await res.json();

        console.log(data);
    } catch (error) {
        console.error(error);
    }
}



addBtn.addEventListener("click", () => {
    logModal.showModal();
});

dateInput.addEventListener("change", (e) => {
    console.log(e.target.value);
});

const groupedByDay = smokerLogs.reduce((accumulator, currentItem) => {
    console.log(new Date(currentItem.date).getUTCDate());
    const year = new Date(currentItem.date).getUTCFullYear();
    const month = new Date(currentItem.date)
        .getUTCMonth()
        .toString()
        .padStart(2, "0");

    const day = new Date(currentItem.date)
        .getUTCDate()
        .toString()
        .padStart(2, "0");

    const dateKey = `${year}-${month}-${day}`;

    if (!accumulator[dateKey]) {
        accumulator[dateKey] = [];
    }

    accumulator[dateKey].push(currentItem);

    return accumulator;
}, {});

console.log(groupedByDay);
const resultAsArray = Object.values(groupedByDay);

console.log(resultAsArray);
