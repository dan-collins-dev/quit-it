<script>
	import graveIconSrc from "$lib/assets/grave-illustration-3-svgrepo-com.svg"

	let { lastLog } = $props();
    
	const avgLifeLossPerCig = 20;

	let count = $derived.by(() => {
		if (isSameUTCDay(lastLog?.date)) {
			return lastLog?.numOfCigs;
		} else {
			return false;
		}
	});

	let totalLifeLost = $derived.by(() => {
		if (count != 0) {
            let totalTime = count * avgLifeLossPerCig
            const days = Math.floor(totalTime / 1440);
            let hours = Math.floor(totalTime / 60);
            let mins = Math.floor(totalTime % 60);

            // let 
			return (`${days} days ${hours} hrs ${mins} mins`);
		} else {
			return (`0 days 0 hrs 0 mins`);
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
	<h2>Life Lost Today</h2>
	<div class="logo-container">
		<img class="card-logo" src={graveIconSrc} alt="" />
	</div>
	<p>{totalLifeLost}</p>

</article>

<style>

	article:hover {
		background-color: #d1ccff;
		box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2);
	}

	h2 {
		color: black;
		/* padding-bottom: 1rem; */
	}

	p {
		color: black;
	}
</style>
