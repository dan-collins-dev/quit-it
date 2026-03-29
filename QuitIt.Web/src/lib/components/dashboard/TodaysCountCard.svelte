<script>
	import cigIconSrc from "$lib/assets/cigarette-svgrepo-com.svg";

	let { lastLog } = $props();

	let date = $derived.by(() => {
		if (isSameUTCDay(lastLog?.date)) {
			const lastDate = new Date(lastLog?.date);
			return lastDate.toDateString();
		} else {
			return new Date().toDateString();
		}
	});

	let count = $derived.by(() => {
		if (isSameUTCDay(lastLog?.date)) {
			return lastLog?.numOfCigs;
		} else {
			return false;
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
	<h2>{date}</h2>
	<div class="logo-container">
		<img class="card-logo" src={cigIconSrc} alt="" />
	</div>
	<p class="card-number">{count || 0}</p>
	<p class="card-category">Cigarettes Smoked Today</p>
</article>

<style>
	h2 {
		color: black;
	}

	.card-category {
		font-size: 1rem;
		color: black;
	}
</style>
