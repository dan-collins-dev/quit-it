<script>
	// import { onMount } from "svelte";

	import StreakCard from "$lib/components/dashboard/StreakCard.svelte";
	import TodaysCountCard from "$lib/components/dashboard/TodaysCountCard.svelte";
	import MoneySmokedCard from "$lib/components/dashboard/MoneySmokedCard.svelte";

	

	// Keep as a reference in case I decide to put logic on +pages

	// let logs = $state([]);

	// let lastLog = $derived.by(() => logs.at(-1) ?? null);

	// async function getData() {
	// 	try {
	// 		const res = await fetch("http://localhost:5150/api/logs");
	// 		logs = await res.json();
	// 	} catch (error) {
	// 		console.log(error);
	// 	}
	// }

	// onMount(getData);
</script>

<section class="card-container">
	<TodaysCountCard />
	<StreakCard />
	<MoneySmokedCard />
</section>

<style>
	.card-container {
		display: grid;
		grid-template-columns: 1fr;
	}
</style>
