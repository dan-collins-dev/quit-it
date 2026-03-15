<script>
	import { onMount } from "svelte";
	import TodaysCount from "$lib/components/dashboard/TodaysCount.svelte";
	import StreakCard from "$lib/components/dashboard/StreakCard.svelte";

	let logs = $state([]);

	let lastLog = $derived.by(() => logs.at(-1) ?? null);

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

<section class="card-container">
	<TodaysCount {lastLog} />
	<StreakCard {lastLog} />

	<!-- <DashboardCard iconSrc={cigIconSrc} label="Cigarettes Smoked Today" count="23" />
	<DashboardCard iconSrc={cashIconSrc} label="Cigarettes Smoked Today" count="$10000.23" />
	<DashboardCard iconSrc={graveIconSrc} label="Cigarettes Smoked Today" count="00:00:00" />
	<DashboardCard iconSrc={cigIconSrc} label="Cigarettes Smoked Today" count="23" />
	<DashboardCard iconSrc={cigIconSrc} label="Cigarettes Smoked Today" count="23" /> -->
</section>

<style>
	.card-container {
		display: grid;
		grid-template-columns: 1fr;
	}
</style>
