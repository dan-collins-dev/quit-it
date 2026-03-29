<script>
	import { fade } from "svelte/transition";
	import { onMount } from "svelte";
	
	import CancerLocationsCard from "../lib/components/home/CancerLocationsCard.svelte";
	import Reason from "$lib/components/home/Reason.svelte";
	import StreakCard from "$lib/components/dashboard/StreakCard.svelte";
	import QuittingBenefits from "$lib/components/home/QuittingBenefits.svelte";

	let loaded = $state(null);
	let error = $state(null);
	let reason = $state(null);

	async function getReasonNotToSmoke() {
		try {
			const res = await fetch("https://reasons-to-quit-smoking-api.vercel.app/api/reasons");
			const data = await res.json();
			return data;
		} catch (error) {
			console.error(error.message);
		}
	}

	onMount(async () => {
		try {
			reason = await getReasonNotToSmoke();
			logs = await getData();
			loaded = true;
		} catch (err) {
			error = err.message;
		}
	});

	let logs = $state([]);

	let lastLog = $derived.by(() => logs.at(-1) ?? null);

	async function getData() {
		try {
			const res = await fetch("http://localhost:5150/api/logs");
			const data = await res.json();
			return data;
		} catch (error) {
			console.log(error);
		}
	}
</script>

<svelte:head>
	<title>Quit It</title>
</svelte:head>

{#if loaded}
	<div in:fade={{ duration: 300 }}>
		<div class="flex-container">
			<Reason {reason} />
			<StreakCard {lastLog} />
		</div>

		<div class="flex-container">
			<CancerLocationsCard />
			<QuittingBenefits />
		</div>
	</div>
{:else if !loaded}
	<article>
		<h2>Loading page...</h2>
	</article>
{:else}
	<article>
		<h2>{error}</h2>
	</article>
{/if}


<style>
	.flex-container {
		display: flex;
		flex-direction: column;
	}

	@media (min-width: 768px) {
		.flex-container {
			flex-direction: row;
			justify-content: stretch;
		}
	}
</style>