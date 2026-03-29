<script>
	import stopIconSrc from "$lib/assets/stop-urgent-svgrepo-com.svg";

	let { reason } = $props();
</script>

<article class="dashboard-card">
	<div class="logo-container">
		<img class="card-logo" src={stopIconSrc} alt="" />
	</div>
	<h2>Don't do it!</h2>
	<p>{reason}</p>
	<p class="citation">
		Special thanks to <a href="https://github.com/LiminalElenyx">LiminalElenyx</a> for contributing
	</p>
</article>

<style>
	p,
	h2 {
		color: black;
	}

	article {
		flex: 1
	}
</style>
