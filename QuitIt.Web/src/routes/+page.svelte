<script>
	import CancerLocationsCard from "../lib/components/home/CancerLocationsCard.svelte";
	
	import Reason from "$lib/components/home/Reason.svelte";

	import {fade} from "svelte/transition"

	import { onMount } from "svelte";
	import StreakCard from "$lib/components/dashboard/StreakCard.svelte";


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
			// onLoaded();
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
			return data
		} catch (error) {
			console.log(error);
		}
	}

	// onMount(getData);
</script>

<svelte:head>
	<title>Quit It</title>
</svelte:head>

{#if loaded}
	<div in:fade={{duration: 300}}>
		<Reason {reason}/>
		<StreakCard {lastLog}/>
		<CancerLocationsCard/>
	</div>
{:else if !loaded}
	<article >
		<h2>Loading page...</h2>
		<div class="logo-container">
			<!-- <img class="cig-logo" src={cigIconSrc} alt="" /> -->
		</div>
	</article>
{:else}
	<article>
		<h2>{error}</h2>
		<div class="logo-container">
			<!-- <img class="cig-logo" src={cigIconSrc} alt="" /> -->
		</div>
	</article>
{/if}
