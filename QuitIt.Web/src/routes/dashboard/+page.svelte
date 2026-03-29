<script>
	import { onMount } from "svelte";

	import TodaysCountCard from "$lib/components/dashboard/TodaysCountCard.svelte";
	import MoneySmokedCard from "$lib/components/dashboard/MoneySmokedCard.svelte";
	import LastSevenDaysCountCard from "$lib/components/dashboard/LastSevenDaysCountCard.svelte";
	import LifeConsumedTodayCard from "$lib/components/dashboard/LifeConsumedTodayCard.svelte";
	import LifeConsumedSevenDaysCard from "$lib/components/dashboard/LifeConsumedSevenDaysCard.svelte";
	import LastSevenDaysMoneySmokedCard from "$lib/components/dashboard/LastSevenDaysMoneySmokedCard.svelte";
	import AllTimeCigsSmokedCard from "$lib/components/dashboard/AllTimeCigsSmokedCard.svelte";
	import AllTimeMoneySmokedCard from "$lib/components/dashboard/AllTimeMoneySmokedCard.svelte";
	import AllTimeLifeConsumedCard from "$lib/components/dashboard/AllTimeLifeConsumedCard.svelte";

	let logs = $state([]);

	let lastLog = $derived.by(() => logs.at(-1));

	async function getData() {
		try {
			const res = await fetch("http://localhost:5150/api/logs");
			logs = await res.json();
		} catch (error) {
			console.log(error);
		}
	}

	onMount(getData);
</script>

<svelte:head>
	<title>Quit It | Dashboard</title>
</svelte:head>

<section>
	<article class="dashboard-card">
		<h2>Today's Stats</h2>
		<p>{new Date().toDateString()}</p>
	</article>

	<div class="card-container">
		<TodaysCountCard {lastLog} />
		<MoneySmokedCard {lastLog} />
		<LifeConsumedTodayCard {lastLog} />
	</div>

	<article class="dashboard-card">
		<h2>Past Seven Days</h2>
	</article>

	<div class="card-container">
		<LastSevenDaysCountCard {logs} />
		<LastSevenDaysMoneySmokedCard {logs} />
		<LifeConsumedSevenDaysCard {logs} />
	</div>

	<article class="dashboard-card">
		<h2>All Time</h2>
	</article>

	<div class="card-container">
		<AllTimeCigsSmokedCard {logs} />
		<AllTimeMoneySmokedCard {logs} />
		<AllTimeLifeConsumedCard {logs} />
	</div>
</section>

<style>
	.card-container {
		display: grid;
		grid-template-columns: 1fr;
	}

	h2,
	p {
		color: black;
	}

	@media (min-width: 768px) {
		.card-container {
			grid-template-columns: repeat(2, 1fr);
		}
	}

	@media (min-width: 1024px) {
		.card-container {
			grid-template-columns: repeat(3, 1fr);
		}
	}
</style>
