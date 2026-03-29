<script>
	import cigIconSrc from "$lib/assets/cigarette-svgrepo-com.svg";

	let { logs } = $props();

	let lastSevenLogs = $derived(logs.slice(-7));
	let totalLifeLost = $derived.by(() => {
		let count = 0;
		lastSevenLogs.forEach((log) => {
			count += log.numOfCigs;
		});
		return count;
	});
</script>

<article class="dashboard-card">
	<h2>Cigarettes Smoked (Last 7 Days)</h2>
	<div class="logo-container">
		<img class="card-logo" src={cigIconSrc} alt="" />
	</div>
	<p class="card-number">{totalLifeLost || 0}</p>
</article>

<style>
	h2 {
		color: black;
		/* padding-bottom: 1rem; */
		text-align: center;
	}

	/* .card-category {
		font-size: 1rem;
		color: black;
		margin: 0 0 10px 0;
	} */
</style>
