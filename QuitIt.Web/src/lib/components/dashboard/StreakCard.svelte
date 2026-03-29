<script>
	import trophyIconSrc from "$lib/assets/trophy-svgrepo-com.svg";

	let { lastLog } = $props();

	function utcDaysSince(timestampMs) {
		const now = new Date();
		const last = new Date(timestampMs);

		const todayUTC = Date.UTC(now.getUTCFullYear(), now.getUTCMonth(), now.getUTCDate());
		const lastUTC = Date.UTC(last.getUTCFullYear(), last.getUTCMonth(), last.getUTCDate());

		return Math.floor((todayUTC - lastUTC) / 86400000);
	}
</script>

<article class="dashboard-card">
	<h2>Current Streak</h2>
	<div class="logo-container">
		<img class="card-logo" src={trophyIconSrc} alt="" />
	</div>
	<p class="card-number">{utcDaysSince(lastLog?.date)}</p>
	<p>Last cigarette smoked on {new Date(lastLog?.date).toLocaleDateString()}</p>
</article>

<style>
	p,
	h2 {
		color: black;
	}

	article {
		flex: 1;
	}
</style>
