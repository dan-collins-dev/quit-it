<script>
	import TriggerCard from "$lib/components/TriggerCard.svelte";
	import { onMount } from "svelte";

	let triggers = $state([]);
	let triggerInput = $state("");

	async function getData() {
		try {
			const res = await fetch("http://localhost:7070/api/triggers");
			const myTriggers = await res.json();
			return myTriggers;
		} catch (error) {
			console.log(error);
		}
	}

	async function postData() {
		try {
			const res = await fetch("http://localhost:7070/api/triggers", {
				method: "POST",
				headers: {
					"Content-Type": "application/json"
				},

				body: JSON.stringify({ trigger: triggerInput })
			});

			console.log({ trigger: triggerInput });

			const newTrigger = await res.json();
			triggerInput = "";

			triggers.push(newTrigger);
		} catch (error) {
			console.error(error);
		}
	}

	async function putData(id, trigger) {
		try {
			console.log(id)
			const res = await fetch(`http://localhost:7070/api/triggers/${id}`, {
				method: "PUT",
				headers: {
					"Content-Type": "application/json"
				},
				body: JSON.stringify({ trigger: trigger })
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
			console.log(id)
			const res = await fetch(`http://localhost:7070/api/triggers/${id}`, {
				method: "DELETE",
				headers: {
					"Content-Type": "application/json"
				},
			});

			const data = await res.json();
			console.log(data);

			triggerInput = "";

			triggers = triggers.filter(trigger => trigger.id !== id);
		} catch (error) {
			console.error(error);
		}
	}

	onMount(async () => {
		triggers = await getData();
	});
</script>

<div>
	<input type="text" bind:value={triggerInput} name="" id="" />
	<button onclick={postData}>Submit</button>
	{#each triggers as trigger (trigger.id)}
		<TriggerCard trigger={trigger.trigger} id={trigger.id} onDelete={deleteData} onEdit={putData} />
	{/each}
</div>

<style>
</style>
