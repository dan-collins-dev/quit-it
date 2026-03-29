<script>
	import moneyIconSrc from "$lib/assets/cash-outline.svg";

	let { lastLog } = $props();

	const avgCigPrice = 0.28;

	let count = $derived.by(() => {
		if (isSameUTCDay(lastLog?.date)) {
			return lastLog?.numOfCigs;
		} else {
			return false;
		}
	});

	let amountSmoked = $derived.by(() => {
		if (count != 0) {
			return (count * avgCigPrice).toFixed(2);
		} else {
			return (0.0).toFixed(2);
		}
	});

	function isSameUTCDay(lastLogDate) {
		const today = new Date();
		const lastDate = new Date(lastLogDate);

		return (
			today.getUTCFullYear() === lastDate.getUTCFullYear() &&
			today.getUTCMonth() === lastDate.getUTCMonth() &&
			today.getUTCDate() === lastDate.getUTCDate()
		);
	}
</script>

<article class="dashboard-card">
	<h2>Money Smoked Today</h2>
	<div class="logo-container">
		<img class="card-logo" src={moneyIconSrc} alt="" />
	</div>
	<p class="card-number">${amountSmoked}</p>
	<p></p>
</article>

<style>
	h2 {
		color: black;
		/* padding-bottom: 1rem; */
	}

	p {
		color: black;
	}
</style>
