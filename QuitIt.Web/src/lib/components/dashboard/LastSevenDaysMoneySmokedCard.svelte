<script>
	import moneyIconSrc from "$lib/assets/cash-outline.svg";

	let { logs } = $props();

	const avgCigPrice = 0.28;

	let lastSevenLogs = $derived(logs.slice(-7));

	let count = $derived.by(() => {
		let total = 0;
		lastSevenLogs.forEach((log) => {
			total += log.numOfCigs;
		});
		return total;
	});

	let totalAmountSmoked = $derived.by(() => {
		if (count != 0) {
			return (count * avgCigPrice).toFixed(2);
		} else {
			return (0.0).toFixed(2);
		}
	});
</script>

<article class="dashboard-card">
	<h2>Money Smoked (Last 7 Days)</h2>
	<div class="logo-container">
		<img class="card-logo" src={moneyIconSrc} alt="" />
	</div>
	<p class="card-number">${totalAmountSmoked}</p>
	<p></p>
</article>

<style>
	h2 {
		color: black;
		text-align: center;
	}
</style>
