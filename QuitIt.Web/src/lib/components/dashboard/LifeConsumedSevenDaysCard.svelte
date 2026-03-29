<script>
	import graveIconSrc from "$lib/assets/grave-illustration-3-svgrepo-com.svg";

	let { logs } = $props();

	const avgLifeLossPerCig = 20;

	let lastSevenLogs = $derived(logs.slice(-7));
	let count = $derived.by(() => {
		let total = 0;
		lastSevenLogs.forEach((log) => {
			total += log.numOfCigs;
		});

		return total;
	});

	let totalLifeLost = $derived.by(() => {
		if (count != 0) {
			let totalTime = count * avgLifeLossPerCig;
			const days = Math.floor(totalTime / 1440);
			let hours = Math.floor(totalTime / 60);
			let mins = Math.floor(totalTime % 60);

			// let
			return `${days} days ${hours} hrs ${mins} mins`;
		} else {
			return `0 days 0 hrs 0 mins`;
		}
	});
</script>

<article class="dashboard-card">
	<h2>Life Lost (Last 7 Days)</h2>
	<div class="logo-container">
		<img class="card-logo" src={graveIconSrc} alt="" />
	</div>
	<p>{totalLifeLost}</p>
</article>

<style>
	h2 {
		color: black;
	}

	p {
		color: black;
	}
</style>
