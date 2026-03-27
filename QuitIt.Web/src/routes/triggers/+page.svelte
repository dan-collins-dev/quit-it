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
		try {
			const res = await fetch("http://localhost:5150/api/triggers", {
				method: "POST",
				headers: {
					"Content-Type": "application/json"
				},

				body: JSON.stringify({ reason: triggerInput })
			});

			console.log({ reason: triggerInput });

			const newTrigger = await res.json();
			triggerInput = "";

			triggers.push(newTrigger);
		} catch (error) {
			console.error(error);
		}
	}

	async function putData(id, trigger) {
		try {
			console.log(id);
			const res = await fetch(`http://localhost:5150/api/triggers/${id}`, {
				method: "PUT",
				headers: {
					"Content-Type": "application/json"
				},
				body: JSON.stringify({ reason: trigger })
			});

			const data = await res.json();
			console.log(data);

			triggers = [...triggers];
		} catch (error) {
			console.error(error);
		}
	}

	async function deleteData(id) {
		try {
			console.log(id);
			const res = await fetch(`http://localhost:5150/api/triggers/${id}`, {
				method: "DELETE",
				headers: {
					"Content-Type": "application/json"
				}
			});

			const data = await res.json();
			console.log(data);

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

<div>
	<article>
		<h2>Manage Your Triggers</h2>
		<AddTriggerInput bind:value={triggerInput} />
		<button onclick={postData}>Submit</button>
	</article>
	{#each triggers as trigger (trigger.id)}
		<TriggerCard trigger={trigger.reason} id={trigger.id} onDelete={deleteData} onEdit={putData} />
	{/each}
</div>

<style>
	article {
		display: flex;
		flex-direction: column;
		justify-content: space-between;
		background-color: #fff;
		border-radius: 5px;
		box-shadow: 0 4px 8px 0 #00000033;
		padding: 1rem;
		margin: 0.75rem;
		color: black;
		gap: 1rem;
	}

	button {
		border: none;
		padding: 1rem 2rem;
		border-radius: 5px;
		background: linear-gradient(180deg, #6f8000, #003600);
		color: white;
	}
</style>
