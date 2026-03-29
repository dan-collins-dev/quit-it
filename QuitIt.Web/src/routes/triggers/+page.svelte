<script>
	import TriggerCard from "$lib/components/triggers/TriggerCard.svelte";
	import AddTriggerInput from "$lib/components/triggers/AddTriggerInput.svelte";
	import { onMount } from "svelte";

	let triggers = $state([]);
	let triggerInput = $state("");

	async function getData() {
		try {
			const res = await fetch("http://localhost:5150/api/triggers");
			const myTriggers = await res.json();
			return myTriggers;
		} catch (error) {
			console.log(error);
		}
	}

	async function postData() {
		if (triggerInput === "") return;

		try {
			const res = await fetch("http://localhost:5150/api/triggers", {
				method: "POST",
				headers: {
					"Content-Type": "application/json"
				},

				body: JSON.stringify({ reason: triggerInput })
			});

			// console.log({ reason: triggerInput });

			const newTrigger = await res.json();
			triggerInput = "";

			triggers.push(newTrigger);
		} catch (error) {
			console.error(error);
		}
	}

	async function putData(id, trigger) {
		try {
			// console.log(id);
			const res = await fetch(`http://localhost:5150/api/triggers/${id}`, {
				method: "PUT",
				headers: {
					"Content-Type": "application/json"
				},
				body: JSON.stringify({ reason: trigger })
			});

			await res.json();

			const updatedTriggerIndex = triggers.findIndex((trigger) => trigger.id == id);
			triggers.splice(updatedTriggerIndex, 0);
		} catch (error) {
			console.error(error);
		}
	}

	async function deleteData(id) {
		try {
			const res = await fetch(`http://localhost:5150/api/triggers/${id}`, {
				method: "DELETE",
				headers: {
					"Content-Type": "application/json"
				}
			});

			await res.json();
			triggerInput = "";

			triggers = triggers.filter((trigger) => trigger.id !== id);
		} catch (error) {
			console.error(error);
		}
	}

	onMount(async () => {
		triggers = await getData();
	});
</script>

<svelte:head>
	<title>Quit It | Triggers</title>
</svelte:head>

<article class="trigger-card">
	<h2>Manage Your Triggers</h2>
	<AddTriggerInput bind:value={triggerInput} />
	<button onclick={postData}>Submit</button>
</article>
<div class="trigger-container">
	{#each triggers as trigger (trigger.id)}
		<TriggerCard trigger={trigger.reason} id={trigger.id} onDelete={deleteData} onEdit={putData} />
	{/each}
</div>

<style>


	button {
		border: none;
		padding: 1rem 2rem;
		border-radius: 5px;
		background: linear-gradient(180deg, #6f8000, #003600);
		color: white;
	}

	.trigger-container {
		display: grid;
		grid-template-columns: 1fr;
	}

	@media (min-width: 768px) {
		.trigger-container {
			grid-template-columns: 1fr 1fr;
		}
	}

	@media (min-width: 1024px) {
		.trigger-container {
			grid-template-columns: repeat(3, 1fr);
		}
	}
</style>
