<script>
	import cigIconSrc from "$lib/assets/cash-outline.svg";
	let { lastLog } = $props();

	let avgCigPrice = 0.28;

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
		<img class="cig-logo" src={cigIconSrc} alt="" />
	</div>
	<p class="card-number">${amountSmoked}</p>
</article>

<style>
	article {
		display: flex;
		flex-direction: column;
		align-items: center;
		background-color: #fff;
		border-radius: 5px;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
		padding: 1rem;
		margin: 0.75rem;
		transition: 0.3s;
	}

	article:hover {
		background-color: #d1ccff;
		box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2);
	}

	h2 {
		color: black;
		padding-bottom: 1rem;
	}
</style>
