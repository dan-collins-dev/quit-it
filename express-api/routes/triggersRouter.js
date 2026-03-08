import express from "express";
import path from "path";
import { fileURLToPath } from "url";
import fs from "fs/promises";
import { v4 } from "uuid";

const triggerRouter = express.Router();

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);
const triggersFilePath = path.join(__dirname, "..", "data", "triggers.json");

async function getAllTriggers() {
    try {
        const triggerData = await fs.readFile(triggersFilePath);
        return JSON.parse(triggerData);
    } catch (error) {
        console.error(error.message);
    }
}

triggerRouter.get("/", async (req, res) => {
    const triggers = await getAllTriggers();
    res.status(200).json(triggers);
});

triggerRouter.post("/", async (req, res) => {
    if (!req.body || !req.body.trigger) {
        return res.status(400).json("Bad");
    }

    try {
        const triggers = await getAllTriggers();
        const newTrigger = { id: v4(), trigger: req.body.trigger };
        triggers.push(newTrigger);
        await fs.writeFile(triggersFilePath, JSON.stringify(triggers));

        res.status(201).json(newTrigger);
    } catch (error) {
        console.error(error.message);
    }
});

triggerRouter.delete("/:id", async (req, res) => {
    if (!req.params.id) {
        return res.status(404).json({
            error: "Post with that id does not exist",
        });
    }

    try {
        const id = req.params.id;
        let triggers = await getAllTriggers();
        const trigger = triggers.find((trigger) => trigger.id == id);

        if (!trigger) {
            return res.status(404).json({
                error: `A trigger with the id, ${id}, does not exist`,
            });
        }

        triggers = triggers.filter((trigger) => trigger.id !== id);
        await fs.writeFile(triggersFilePath, JSON.stringify(triggers));

        res.status(200).json({
            message: "Record deleted",
        });
    } catch (error) {
        console.error(error.message);
    }
});

export default triggerRouter;
